using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;

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
        public virtual Task<IWebApiResponse> OnRequestAsync(MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken = default)
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

            HashSet<string>? idsList = null;
            if (context.Request.Options.EndpointQuery.TryGetValue(context.Request.Options.BulkQueryParameterIdsName, out string? ids))
                idsList = new HashSet<string>(ids.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

            if (idsList?.Contains(ALL) == true)
                return OnAllRequestAsync(context, callNext, cancellationToken);

            return (idsList?.Count ?? 0) switch
            {
                0 => OnEndpointRequestAsync(context, callNext, cancellationToken),
                _ => OnManyRequestAsync(context, idsList!, callNext, cancellationToken)
            };
        }

        private static async Task<IWebApiResponse> OnEndpointRequestAsync(MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            string cacheCategory = context.Request.Options.EndpointPath;
            string cacheId = GetCacheId(context.Request, context.Request.Options.PathSuffix.OrIfNullOrEmpty("_index"));
            var cacheItem = await context.Connection.CacheMethod
                .GetOrUpdateAsync(cacheCategory, cacheId, (cacheCategory, cacheId) =>
                    RequestGetAsync(cacheCategory, cacheId, context, callNext, cancellationToken))
                .ConfigureAwait(false);

            var response = new WebApiResponse(cacheItem.StringItem, cacheItem.StatusCode, cacheItem.Metadata);
            response.ResponseHeaders[HttpResponseInfo.CACHE_STATE_HEADER] = GetCacheState(cacheItem).ToString();
            return response;
        }

        private static async Task<IWebApiResponse> OnManyRequestAsync(MiddlewareContext context,
            ISet<string> ids,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            string cacheCategory = context.Request.Options.EndpointPath;
            var cacheItems = await context.Connection.CacheMethod
                .GetOrUpdateManyAsync(cacheCategory, ids, (cacheCategory, missingIds) =>
                    RequestManyAsync(cacheCategory, missingIds, context, callNext, cancellationToken))
                .ConfigureAwait(false);

            var response = cacheItems.Select(x => new WebApiResponse(x.StringItem, x.StatusCode, x.Metadata)).Merge();
            response.ResponseHeaders[HttpResponseInfo.CACHE_STATE_HEADER] = GetCacheState(cacheItems).ToString();
            return response;
        }

        private static async Task<IWebApiResponse> OnAllRequestAsync(MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            string cacheCategory = context.Request.Options.EndpointPath;
            string cacheId = GetCacheId(context.Request, "_all");
            var cacheItem = await context.Connection.CacheMethod.
                GetOrUpdateAsync(cacheCategory, cacheId, (cacheCategory, cacheId) =>
                    RequestGetAsync(cacheCategory, cacheId, context, callNext, cancellationToken))
                .ConfigureAwait(false);

            var response = new WebApiResponse(cacheItem.StringItem, cacheItem.StatusCode, cacheItem.Metadata);
            response.ResponseHeaders[HttpResponseInfo.CACHE_STATE_HEADER] = GetCacheState(cacheItem).ToString();

            // Update individual items
            var cacheItems = SplitResponseIntoIndividualCacheObjects(cacheCategory, response, context.Request.Options.BulkObjectIdName);
            await context.Connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return response;
        }

        private static async Task<IWebApiResponse> OnPageRequestAsync(MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            context.Request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE, out string? page);
            context.Request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE_SIZE, out string? pageSize);

            string cacheCategory = context.Request.Options.EndpointPath;
            string cacheId = GetCacheId(context.Request, $"_page{page}-{pageSize}");
            var cacheItem = await context.Connection.CacheMethod
                .GetOrUpdateAsync(cacheCategory, cacheId, (cacheCategory, cacheId) =>
                    RequestGetAsync(cacheCategory, cacheId, context, callNext, cancellationToken))
                .ConfigureAwait(false);

            var response = new WebApiResponse(cacheItem.StringItem, cacheItem.StatusCode, cacheItem.Metadata);
            response.ResponseHeaders[HttpResponseInfo.CACHE_STATE_HEADER] = GetCacheState(cacheItem).ToString();

            // Update individual items
            var cacheItems = SplitResponseIntoIndividualCacheObjects(cacheCategory, response, context.Request.Options.BulkObjectIdName);
            await context.Connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return response;
        }

        private static async Task<CacheItem> RequestGetAsync(string cacheCategory,
            string cacheId,
            MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            var response = await callNext(context, cancellationToken).ConfigureAwait(false);
            var responseInfo = new HttpResponseInfo(response.StatusCode, response.ResponseHeaders.AsReadOnly());
            return new CacheItem(cacheCategory, cacheId, response.Content, response.StatusCode,
                responseInfo.Expires.GetValueOrDefault(DateTimeOffset.Now), CacheItemStatus.New, response.ResponseHeaders);
        }

        private static async Task<IList<CacheItem>> RequestManyAsync(string cacheCategory,
            IEnumerable<string> cacheIds,
            MiddlewareContext context,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext,
            CancellationToken cancellationToken)
        {
            var newContext = new MiddlewareContext(context.Connection, context.Request.DeepCopy());
            newContext.Request.Options.EndpointQuery[context.Request.Options.BulkQueryParameterIdsName] = string.Join(",", cacheIds);

            var response = await callNext(newContext, cancellationToken).ConfigureAwait(false);
            return SplitResponseIntoIndividualCacheObjects(cacheCategory, response, context.Request.Options.BulkObjectIdName);
        }

        private static IList<CacheItem> SplitResponseIntoIndividualCacheObjects(string cacheCategory, IWebApiResponse response, string bulkObjectPropertyIdName)
        {
            var responseInfo = new HttpResponseInfo(response.StatusCode, response.ResponseHeaders.AsReadOnly());

            var items = new List<CacheItem>();

            using var doc = JsonDocument.Parse(response.Content);
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                if (item.TryGetProperty(bulkObjectPropertyIdName, out var id))
                {
                    items.Add(new CacheItem(cacheCategory, id.ToString(), item.GetRawText(), response.StatusCode,
                        responseInfo.Expires.GetValueOrDefault(DateTimeOffset.Now), CacheItemStatus.New, response.ResponseHeaders));
                }
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

        private static CacheState GetCacheState(CacheItem cacheItem) => cacheItem.Status switch
        {
            CacheItemStatus.Cached => CacheState.FromCache,
            _ => CacheState.FromLive
        };

        private static CacheState GetCacheState(IList<CacheItem> cacheItems)
        {
            int fCacheCount = cacheItems.Count(x => GetCacheState(x) == CacheState.FromCache);
            return fCacheCount switch
            {
                0 => CacheState.FromLive,
                _ when fCacheCount == cacheItems.Count => CacheState.FromCache,
                _ => CacheState.PartiallyFromCache
            };
        }
    }
}
