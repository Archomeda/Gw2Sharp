using System;
using System.Collections.Generic;
using System.IO;
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
        public virtual Task<IWebApiResponse> OnRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
        {
            if (connection is null)
                throw new ArgumentNullException(nameof(connection));
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            if (callNext is null)
                throw new ArgumentNullException(nameof(callNext));

            //TODO Split requests with more than 200 ids

            // Gw2Sharp only supports requesting pages separately, and not combined with a list of ids (or all).
            // Even though it's supported by the API, it doesn't really make much sense to use it with a given list of ids
            // (just split the list, or leave out all).
            if (request.Options.EndpointQuery.ContainsKey(QUERY_PARAM_PAGE))
                return OnPageRequestAsync(connection, request, callNext, cancellationToken);

            string[] idsList = Array.Empty<string>();
            if (request.Options.EndpointQuery.TryGetValue(request.Options.BulkQueryParameterIdsName, out string? ids))
                idsList = ids.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (idsList.Contains(ALL, StringComparer.OrdinalIgnoreCase))
                return OnAllRequestAsync(connection, request, callNext, cancellationToken);

            return idsList.Length switch
            {
                0 => OnEndpointRequestAsync(connection, request, callNext, cancellationToken),
                _ => OnManyRequestAsync(connection, request, idsList, callNext, cancellationToken)
            };
        }

        private static async Task<IWebApiResponse> OnEndpointRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItem = await connection.CacheMethod.GetOrUpdateAsync(request.Options.EndpointPath, "_index",
                RequestGetAsync(request, callNext, cancellationToken)).ConfigureAwait(false);
            return cacheItem.Item;
        }

        private static async Task<IWebApiResponse> OnManyRequestAsync(IConnection connection, IWebApiRequest request, IEnumerable<string> ids, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItems = await connection.CacheMethod.GetOrUpdateManyAsync(request.Options.EndpointPath, ids, async missingIds =>
            {
                var newRequest = request.DeepCopy();
                newRequest.Options.EndpointQuery[request.Options.BulkQueryParameterIdsName] = string.Join(",", missingIds);

                var response = await callNext(newRequest, cancellationToken).ConfigureAwait(false);
                var responseInfo = new ApiV2HttpResponseInfo(response.StatusCode, response.ResponseHeaders);
                return (SplitIntoIndividualResponses(response, request.Options.BulkObjectIdName), GetExpires(responseInfo));
            }).ConfigureAwait(false);
            return MergeIndividualResponses(cacheItems.Select(x => x.Item));
        }

        private static async Task<IWebApiResponse> OnAllRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            var cacheItem = await connection.CacheMethod.GetOrUpdateAsync(request.Options.EndpointPath, "_all",
                RequestGetAsync(request, callNext, cancellationToken)).ConfigureAwait(false);

            // Update individual items
            var cacheItems = SplitIntoIndividualResponses(cacheItem.Item, request.Options.BulkObjectIdName)
                .Select(x => new CacheItem<IWebApiResponse>(request.Options.EndpointPath, x.Key, x.Value, cacheItem.ExpiryTime));
            await connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return cacheItem.Item;
        }

        private static async Task<IWebApiResponse> OnPageRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken)
        {
            request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE, out string? page);
            request.Options.EndpointQuery.TryGetValue(QUERY_PARAM_PAGE_SIZE, out string? pageSize);

            var cacheItem = await connection.CacheMethod.GetOrUpdateAsync(request.Options.EndpointPath, $"_page{page}-{pageSize}",
                RequestGetAsync(request, callNext, cancellationToken)).ConfigureAwait(false);

            // Update individual items
            var cacheItems = SplitIntoIndividualResponses(cacheItem.Item, request.Options.BulkObjectIdName)
                .Select(x => new CacheItem<IWebApiResponse>(request.Options.EndpointPath, x.Key, x.Value, cacheItem.ExpiryTime));
            await connection.CacheMethod.SetManyAsync(cacheItems).ConfigureAwait(false);

            return cacheItem.Item;
        }

        private static Func<Task<(IWebApiResponse, DateTimeOffset)>> RequestGetAsync(IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken) =>
            async () =>
            {
                var response = await callNext(request, cancellationToken).ConfigureAwait(false);
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
                string id = item.GetProperty(bulkObjectPropertyIdName).ToString();
                items[id] = new WebApiResponse(item.GetRawText(), response.StatusCode, response.ResponseHeaders);
            }

            return items;
        }

        private static IWebApiResponse MergeIndividualResponses(IEnumerable<IWebApiResponse> responses)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (var response in responses)
            {
                using var doc = JsonDocument.Parse(response.Content);
                doc.RootElement.WriteTo(writer);
            }
            writer.WriteEndArray();
            writer.Flush();

            stream.Position = 0;
            var firstResponse = responses.FirstOrDefault();
            using var reader = new StreamReader(stream);
            return new WebApiResponse(reader.ReadToEnd(), firstResponse?.StatusCode, firstResponse?.ResponseHeaders);
        }

        /// <summary>
        /// Gets the cache id from a given request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns></returns>
        protected virtual string GetCacheId(IWebApiRequest request, string suffix)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string id = suffix ?? string.Empty;
            request.Options.RequestHeaders.TryGetValue("Accept-Language", out string? language);
            request.Options.RequestHeaders.TryGetValue("Authorization", out string? authorization);
            if (!string.IsNullOrEmpty(language))
                id = $"{language}_{id}";
            if (!string.IsNullOrEmpty(authorization))
                id = $"{authorization.GetSha1Hash()}_{id}";
            return id;
        }
    }
}
