using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointClient<TObject> : BaseClient, IEndpointClient
    {
        private const int MaxPageSize = 200;

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointClient(IConnection connection) : base(connection)
        {
            this.EndpointPath = this.GetRequiredAttribute<EndpointPathAttribute>().EndpointPath;

            this.IsLocalized = this.ImplementsInterface(typeof(ILocalizedClient<>));
            this.IsAuthenticated = this.ImplementsInterface(typeof(IAuthenticatedClient<>));
            this.IsPaginated = this.ImplementsInterface(typeof(IPaginatedClient<>));
            this.IsAllExpandable = this.ImplementsInterface(typeof(IAllExpandableClient<>));
            this.IsBulkExpandable = this.ImplementsInterface(typeof(IBulkExpandableClient<,>));
            this.HasBlobData = this.ImplementsInterface(typeof(IBlobClient<>));

            if (this.HasBlobData && (this.IsAllExpandable || this.IsBulkExpandable))
                throw new InvalidOperationException("An endpoint cannot implement all or bulk expansion in combination with blob data.");
        }

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointClient(IConnection connection, params string[] replaceSegments) : this(connection)
        {
            var segments = this.GetRequiredAttributes<EndpointPathSegmentAttribute>().OrderBy(a => a.Order).ToList();
            if (segments.Count != replaceSegments.Length)
                throw new InvalidOperationException($"The defined amount of path segments ({segments.Count}) does not equal to the passed amount of replacment segments ({replaceSegments.Length})");

            for (int i = 0; i < segments.Count; i++)
                this.EndpointPath = this.EndpointPath.Replace($":{segments[i].PathSegment}", replaceSegments[i]);
        }

        /// <inheritdoc />
        public string EndpointPath { get; }


        /// <inheritdoc />
        public bool IsPaginated { get; }

        /// <inheritdoc />
        public bool IsAuthenticated { get; }

        /// <inheritdoc />
        public bool IsLocalized { get; }

        /// <inheritdoc />
        public bool HasBlobData { get; }

        /// <inheritdoc />
        public bool IsAllExpandable { get; }

        /// <inheritdoc />
        public bool IsBulkExpandable { get; }


        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>All entries.</returns>
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestAll<TIdentifiableObject, TId>() where TIdentifiableObject : IIdentifiable<TId> =>
            this.RequestAll<TIdentifiableObject, TId>(CancellationToken.None);

        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestAll<TIdentifiableObject, TId>(CancellationToken cancellationToken) where TIdentifiableObject : IIdentifiable<TId> =>
            (await this.RequestAllWithResponse<TIdentifiableObject, TId>(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests all entries from this endpoint with the detailed response info.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TIdentifiableObject>>> RequestAllWithResponse<TIdentifiableObject, TId>(CancellationToken cancellationToken)
            where TIdentifiableObject : IIdentifiable<TId>
        {
            var (response, cacheAll) = await GetOrUpdate<IReadOnlyList<TIdentifiableObject>>(this.UrlFormatQueryAll(this.EndpointPath), "_all", cancellationToken).ConfigureAwait(false);
            var cacheIndividuals = await UpdateIndividuals<TIdentifiableObject, TId>(cacheAll).ConfigureAwait(false);
            response.Content = cacheIndividuals.Select(x => x.Item).ToList();
            return response;
        }

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>Entry ids.</returns>
        protected Task<IReadOnlyList<TId>> RequestIds<TId>() =>
            this.RequestIds<TId>(CancellationToken.None);

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        protected async Task<IReadOnlyList<TId>> RequestIds<TId>(CancellationToken cancellationToken) =>
            (await this.RequestIdsWithResponse<TId>(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests the list of entry ids from this endpoint with the detailed response info.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TId>>> RequestIdsWithResponse<TId>(CancellationToken cancellationToken)
        {
            var (response, cache) = await GetOrUpdate<IReadOnlyList<TId>>(this.UrlFormatQueryIds(this.EndpointPath), "_ids", cancellationToken).ConfigureAwait(false);
            response.Content = cache.Item;
            return response;
        }

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <returns>The blob data.</returns>
        protected Task<TObject> RequestGet() =>
            this.RequestGet(CancellationToken.None);

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        protected async Task<TObject> RequestGet(CancellationToken cancellationToken) =>
            (await this.RequestGetWithResponse(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests the main blob data from this endpoint with the detailed response info.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        protected async Task<IApiV2Response<TObject>> RequestGetWithResponse(CancellationToken cancellationToken)
        {
            var (response, cache) = await GetOrUpdate<TObject>(this.UrlFormatQueryBlob(this.EndpointPath), "_index", cancellationToken).ConfigureAwait(false);
            response.Content = cache.Item;
            return response;
        }

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <returns>The entry.</returns>
        protected Task<TIdentifiableObject> RequestGet<TIdentifiableObject, TId>(TId id) where TIdentifiableObject : IIdentifiable<TId> =>
            this.RequestGet<TIdentifiableObject, TId>(id, CancellationToken.None);

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        protected async Task<TIdentifiableObject> RequestGet<TIdentifiableObject, TId>(TId id, CancellationToken cancellationToken) where TIdentifiableObject : IIdentifiable<TId> =>
            (await this.RequestGetWithResponse<TIdentifiableObject, TId>(id, cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a single entry by id with the detailed response info.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        protected async Task<IApiV2Response<TIdentifiableObject>> RequestGetWithResponse<TIdentifiableObject, TId>(TId id, CancellationToken cancellationToken)
            where TIdentifiableObject : IIdentifiable<TId>
        {
            var (response, cache) = await this.GetOrUpdate<TIdentifiableObject>(this.UrlFormatQueryItem(this.EndpointPath, id), id, cancellationToken).ConfigureAwait(false);
            response.Content = cache.Item;
            return response;
        }

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <returns>The entries.</returns>
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestMany<TIdentifiableObject, TId>(IEnumerable<TId> ids) where TIdentifiableObject : IIdentifiable<TId> =>
            this.RequestMany<TIdentifiableObject, TId>(ids, CancellationToken.None);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestMany<TIdentifiableObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken) where TIdentifiableObject : IIdentifiable<TId> =>
            (await this.RequestManyWithResponse<TIdentifiableObject, TId>(ids, cancellationToken).ConfigureAwait(false)).SelectMany(x => x.Content).ToList();

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        protected async Task<IReadOnlyList<IApiV2Response<IReadOnlyList<TIdentifiableObject>>>> RequestManyWithResponse<TIdentifiableObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TIdentifiableObject : IIdentifiable<TId>
        {
            var responses = new List<ApiV2Response<IReadOnlyList<TIdentifiableObject>>>();
            object responsesLock = new object();

            var cache = await this.Connection.CacheMethod.GetOrUpdateMany<TIdentifiableObject>(this.EndpointPath, ids.Cast<object>(),
                async missingIds =>
                {
                    var requestIds = new List<IEnumerable<object>>();
                    for (int i = 0; i < missingIds.Count; i += MaxPageSize)
                        requestIds.Add(missingIds.Skip(i).Take(MaxPageSize));

                    var latestCacheTime = DateTime.Now;
                    var result = await Task.WhenAll(requestIds.Select(async innerIds =>
                    {
                        Uri uri = new Uri(Gw2WebApiV2Client.UrlBase, this.UrlFormatQueryMany(this.EndpointPath, innerIds));
                        var httpResponse = await this.Connection.Request<IReadOnlyList<TIdentifiableObject>>(uri, cancellationToken).ConfigureAwait(false);
                        var response = new ApiV2Response<IReadOnlyList<TIdentifiableObject>>(httpResponse);
                        lock (responsesLock)
                        {
                            responses.Add(response);
                            if (response.Expires.HasValue && latestCacheTime < response.Expires)
                                latestCacheTime = response.Expires.Value;
                        }
                        return response.Content.ToDictionary(x => (object)x.Id, x => x);
                    })).ConfigureAwait(false);

                    return (result.SelectMany(x => x).ToDictionary(kvp => kvp.Key, kvp => kvp.Value), latestCacheTime);
                }
            ).ConfigureAwait(false);

            // We just include the full list of items in every separate response, because
            // it's too complicated to put them into their respective responses.
            var items = cache.Select(x => x.Item).ToList();
            return responses.Select(r => (IApiV2Response<IReadOnlyList<TIdentifiableObject>>)new ApiV2Response<IReadOnlyList<TIdentifiableObject>>(r) { Content = items }).ToList();
        }

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestPage<TIdentifiableObject, TId>(int page, int pageSize = MaxPageSize) where TIdentifiableObject : IIdentifiable<TId> =>
            this.RequestPage<TIdentifiableObject, TId>(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestPage<TIdentifiableObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize) where TIdentifiableObject : IIdentifiable<TId> =>
            (await this.RequestPageWithResponse<TIdentifiableObject, TId>(page, cancellationToken, pageSize).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TIdentifiableObject>>> RequestPageWithResponse<TIdentifiableObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize)
            where TIdentifiableObject : IIdentifiable<TId>
        {
            pageSize = pageSize.Clamp(1, 200);

            var (response, cache) = await GetOrUpdate<IReadOnlyList<TIdentifiableObject>>(this.UrlFormatQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividuals<TIdentifiableObject, TId>(cache).ConfigureAwait(false);

            return new ApiV2Response<IReadOnlyList<TIdentifiableObject>>(response) { Content = cache.Item };
        }

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected Task<TObject> RequestPage(int page, int pageSize = MaxPageSize) =>
            this.RequestPage(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<TObject> RequestPage(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize) =>
            (await this.RequestPageWithResponse(page, cancellationToken, pageSize).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IApiV2Response<TObject>> RequestPageWithResponse(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize)
        {
            pageSize = pageSize.Clamp(1, 200);

            var (response, cache) = await GetOrUpdate<TObject>(this.UrlFormatQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);

            return new ApiV2Response<TObject>(response) { Content = cache.Item };
        }

        /// <summary>
        /// A helper function that makes an API request for items that do not exist in the cache.
        /// Non-expired items in the cache are skipped for requests and are taken from the cache instead.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <param name="url">The request URL.</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A two-tuple that contains the <see cref="IHttpResponse{TIdentifiableObject}"/> and <see cref="CacheItem{TIdentifiableObject}"/> items.</returns>
        protected async Task<(ApiV2Response<TIdentifiableObject>, CacheItem<TIdentifiableObject>)> GetOrUpdate<TIdentifiableObject>(string url, object cacheId, CancellationToken cancellationToken)
        {
            ApiV2Response<TIdentifiableObject> response = new ApiV2Response<TIdentifiableObject>();
            var result = await this.Connection.CacheMethod.GetOrUpdate(this.EndpointPath, cacheId,
                async () => {
                    Uri uri = new Uri(Gw2WebApiV2Client.UrlBase, url);
                    var httpResponse = await this.Connection.Request<TIdentifiableObject>(uri, cancellationToken).ConfigureAwait(false);
                    response = new ApiV2Response<TIdentifiableObject>(httpResponse);
                    return (httpResponse.Content, response.Expires ?? DateTime.Now);
                }).ConfigureAwait(false);
            return (response, result);
        }

        /// <summary>
        /// Helper function to update individual cache items from a many API request.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <returns>The list of cached items.</returns>
        protected async Task<IReadOnlyList<CacheItem<TIdentifiableObject>>> UpdateIndividuals<TIdentifiableObject, TId>(CacheItem<IReadOnlyList<TIdentifiableObject>> cache)
            where TIdentifiableObject : IIdentifiable<TId>
        {
            var cacheList = cache.Item.Select(x => new CacheItem<TIdentifiableObject>(this.EndpointPath, x.Id, x, cache.ExpiryTime)).ToList();
            await this.Connection.CacheMethod.SetMany(cacheList).ConfigureAwait(false);
            return cacheList;
        }


        private const string QueryAll = "?ids=all";
        private const string QueryItem = "/{0}";
        private const string QueryMany = "?ids={0}";
        private const string QueryPage = "?page={0}&page_size={1}";

        /// <summary>
        /// Formats a URL with querying all items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryAll(string endpointPath) => $"{endpointPath}{QueryAll}";

        /// <summary>
        /// Formats a URL with querying ids.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryIds(string endpointPath) => endpointPath;

        /// <summary>
        /// Formats a URL with querying a blob of data.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryBlob(string endpointPath) => endpointPath;

        /// <summary>
        /// Formats a URL with querying an item.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="id">The item id.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryItem<T>(string endpointPath, T id) => $"{endpointPath}{string.Format(QueryItem, id)}";

        /// <summary>
        /// Formats a URL with querying many items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="ids">The item ids.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryMany<T>(string endpointPath, IEnumerable<T> ids) => $"{endpointPath}{string.Format(QueryMany, string.Join(",", ids))}";

        /// <summary>
        /// Formats a URL with querying a page of items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The formatted URL.</returns>
        private string UrlFormatQueryPage(string endpointPath, int page, int pageSize) => $"{endpointPath}{string.Format(QueryPage, page, pageSize)}";


        private bool ImplementsInterface(Type interfaceType) =>
            this.GetType().GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == interfaceType);

        private T GetRequiredAttribute<T>() where T : Attribute =>
            this.GetRequiredAttributes<T>().First();

        private IReadOnlyList<T> GetRequiredAttributes<T>() where T : Attribute
        {
            var attrs = this.GetType().GetCustomAttributes<T>().ToList();
            if (attrs.Count == 0)
                throw new InvalidOperationException($"{this.GetType().FullName} is required to define one or more attributes of {typeof(T).FullName}");
            return attrs;
        }
    }
}
