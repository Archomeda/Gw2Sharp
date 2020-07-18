using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.WebApi.Middleware
{
    /// <summary>
    /// The cache middleware.
    /// </summary>
    public class CacheMiddleware : IWebApiMiddleware
    {
        private const string QUERY_PARAM_PAGE = "page";
        private const string QUERY_PARAM_PAGE_SIZE = "page_size";
        private const string ALL = "all";

        /// <inheritdoc />
        public virtual Task<IWebApiResponse> OnRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (callNext is null)
                throw new ArgumentNullException(nameof(callNext));

            // Gw2Sharp only supports requesting pages separately, and not combined with a list of ids (or all).
            // Even though it's supported by the API, it doesn't really make much sense to use it with a given list of ids
            // (just split the list, or leave out all).
            if (context.Request.Options.EndpointQuery.ContainsKey(QUERY_PARAM_PAGE))
                return OnPageRequestAsync(context, callNext, cancellationToken);

            string[] idsList = Array.Empty<string>();
            if (context.Request.Options.EndpointQuery.TryGetValue(context.Request.Options.BulkQueryParameterIdsName, out string? ids))
                idsList = ids.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (idsList.Contains(ALL, StringComparer.OrdinalIgnoreCase))
                return OnAllRequestAsync(context, callNext, cancellationToken);

            return idsList.Length switch
            {
                0 => OnEndpointRequestAsync(context, callNext, cancellationToken),
                _ => OnManyRequestAsync(context, idsList, callNext, cancellationToken)
            };
        }

        private static async Task<IWebApiResponse> OnEndpointRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItem = await context.Connection.CacheMethod.GetOrUpdateAsync(context.Request.Options.EndpointPath,
                GetCacheId(context.Request, context.Request.Options.PathSuffix.OrIfNullOrEmpty("_index")),
                RequestGetAsync(context, callNext, cancellationToken)).ConfigureAwait(false);
            return cacheItem.Item;
        }

        private static async Task<IWebApiResponse> OnManyRequestAsync(MiddlewareContext context, IEnumerable<string> ids, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItems = await context.Connection.CacheMethod.GetOrUpdateManyAsync(context.Request.Options.EndpointPath, ids, async missingIds =>
            {
                var newContext = new MiddlewareContext(context.Connection, context.Request.DeepCopy());
                newContext.Request.Options.EndpointQuery[context.Request.Options.BulkQueryParameterIdsName] = string.Join(",", missingIds);

                var response = await callNext(newContext, cancellationToken).ConfigureAwait(false);
                var responseInfo = new ApiV2HttpResponseInfo(response.StatusCode, response.ResponseHeaders);
                return (SplitIntoIndividualResponses(response, context.Request.Options.BulkObjectIdName), GetExpires(responseInfo));
            }).ConfigureAwait(false);
            return cacheItems.Select(x => x.Item).Merge();
        }

        private static async Task<IWebApiResponse> OnAllRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItem = await context.Connection.CacheMethod.GetOrUpdateAsync(context.Request.Options.EndpointPath,
                GetCacheId(context.Request, "_all"),
                RequestGetAsync(context, callNext, cancellationToken)).ConfigureAwait(false);

            // Update individual items
            var cacheItems = SplitIntoIndividualResponses(cacheItem.Item, context.Request.Options.BulkObjectIdName)
                .Select(x => new CacheItem<IWebApiResponse>(context.Request.Options.EndpointPath, x.Key, x.Value, cacheItem.ExpiryTime));
            await context.Connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return cacheItem.Item;
        }

        private static async Task<IWebApiResponse> OnPageRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            context.Request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE, out string? page);
            context.Request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE_SIZE, out string? pageSize);

            var cacheItem = await context.Connection.CacheMethod.GetOrUpdateAsync(context.Request.Options.EndpointPath,
                GetCacheId(context.Request, $"_page{page}-{pageSize}"),
                RequestGetAsync(context, callNext, cancellationToken)).ConfigureAwait(false);

            // Update individual items
            var cacheItems = SplitIntoIndividualResponses(cacheItem.Item, context.Request.Options.BulkObjectIdName)
                .Select(x => new CacheItem<IWebApiResponse>(context.Request.Options.EndpointPath, x.Key, x.Value, cacheItem.ExpiryTime));
            await context.Connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return cacheItem.Item;
        }

        private static Func<Task<(IWebApiResponse, DateTimeOffset)>> RequestGetAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken) =>
            async () =>
            {
                var response = await callNext(context, cancellationToken).ConfigureAwait(false);
                var responseInfo = new ApiV2HttpResponseInfo(response.StatusCode, response.ResponseHeaders);
                return (response, GetExpires(responseInfo));
            };

        private static DateTimeOffset GetExpires(HttpResponseInfo responseInfo) =>
            responseInfo.Expires ?? DateTimeOffset.Now;

        private static IDictionary<string, IWebApiResponse> SplitIntoIndividualResponses(IWebApiResponse response, string bulkObjectPropertyIdName)
        {
            var items = new Dictionary<string, IWebApiResponse>();

            using var doc = JsonDocument.Parse(response.Content);
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                if (item.TryGetProperty(bulkObjectPropertyIdName, out var id))
                    items[id.ToString()] = new WebApiResponse(item.GetRawText(), response.StatusCode, response.ResponseHeaders);
            }

            return items;
        }

        /// <summary>
        /// Gets the cache id from a given request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private static string GetCacheId(IWebApiRequest request, string id)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.Options.RequestHeaders.TryGetValue("Accept-Language", out string? language);
            request.Options.RequestHeaders.TryGetValue("Authorization", out string? authorization);
            if (!string.IsNullOrEmpty(language))
                id = $"{id}_{language}";
            if (!string.IsNullOrEmpty(authorization))
                id = $"{id}_{authorization.GetSha1Hash()}";
            return id;
        }
    }
}
