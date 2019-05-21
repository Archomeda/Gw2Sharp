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
    public abstract class BaseEndpointClient<TObject> : BaseClient, IEndpointClient where TObject : object
    {
        private const int MaxPageSize = 200;

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointClient(IConnection connection) :
            base(connection)
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
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointClient(IConnection connection, params string[] replaceSegments) :
            this(connection)
        {
            var segments = this.GetRequiredAttributes<EndpointPathSegmentAttribute>().OrderBy(a => a.Order).ToList();
            if (segments.Count != replaceSegments.Length)
                throw new InvalidOperationException($"The defined amount of path segments ({segments.Count}) does not equal to the passed amount of replacement segments ({replaceSegments.Length})");

            for (int i = 0; i < segments.Count; i++)
                this.EndpointPath = this.EndpointPath.Replace($":{segments[i].PathSegment}", replaceSegments[i]);
        }

        /// <inheritdoc />
        public string EndpointPath { get; }


        /// <inheritdoc />
        public bool IsPaginated { get; protected set; }

        /// <inheritdoc />
        public bool IsAuthenticated { get; protected set; }

        /// <inheritdoc />
        public bool IsLocalized { get; protected set; }

        /// <inheritdoc />
        public bool HasBlobData { get; protected set; }

        /// <inheritdoc />
        public bool IsAllExpandable { get; protected set; }

        /// <inheritdoc />
        public bool IsBulkExpandable { get; protected set; }


        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>All entries.</returns>
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestAllAsync<TIdentifiableObject, TId>()
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            this.RequestAllAsync<TIdentifiableObject, TId>(CancellationToken.None);

        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestAllAsync<TIdentifiableObject, TId>(CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            (await this.RequestAllWithResponseAsync<TIdentifiableObject, TId>(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests all entries from this endpoint with the detailed response info.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TIdentifiableObject>>> RequestAllWithResponseAsync<TIdentifiableObject, TId>(CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object
        {
            var (response, cacheAll) = await this.GetOrUpdateAsync<IReadOnlyList<TIdentifiableObject>>(this.FormatUrlQueryAll(this.EndpointPath), "_all", cancellationToken).ConfigureAwait(false);
            var cacheIndividuals = await this.UpdateIndividualsAsync<TIdentifiableObject, TId>(cacheAll).ConfigureAwait(false);
            response.Content = cacheIndividuals.Select(x => x.Item).ToList();
            return response;
        }

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>Entry ids.</returns>
        protected Task<IReadOnlyList<TId>> RequestIdsAsync<TId>() =>
            this.RequestIdsAsync<TId>(CancellationToken.None);

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        protected async Task<IReadOnlyList<TId>> RequestIdsAsync<TId>(CancellationToken cancellationToken) =>
            (await this.RequestIdsWithResponseAsync<TId>(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests the list of entry ids from this endpoint with the detailed response info.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TId>>> RequestIdsWithResponseAsync<TId>(CancellationToken cancellationToken)
        {
            var (response, cache) = await this.GetOrUpdateAsync<IReadOnlyList<TId>>(this.FormatUrlQueryIds(this.EndpointPath), "_ids", cancellationToken).ConfigureAwait(false);
            response.Content = cache.Item;
            return response;
        }

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <returns>The blob data.</returns>
        protected Task<TObject> RequestGetAsync() =>
            this.RequestGetAsync(CancellationToken.None);

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        protected async Task<TObject> RequestGetAsync(CancellationToken cancellationToken) =>
            (await this.RequestGetWithResponseAsync(cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests the main blob data from this endpoint with the detailed response info.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        protected async Task<IApiV2Response<TObject>> RequestGetWithResponseAsync(CancellationToken cancellationToken)
        {
            var (response, cache) = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryBlob(this.EndpointPath), "_index", cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        protected Task<TIdentifiableObject> RequestGetAsync<TIdentifiableObject, TId>(TId id)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            this.RequestGetAsync<TIdentifiableObject, TId>(id, CancellationToken.None);

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        protected async Task<TIdentifiableObject> RequestGetAsync<TIdentifiableObject, TId>(TId id, CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            (await this.RequestGetWithResponseAsync<TIdentifiableObject, TId>(id, cancellationToken).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a single entry by id with the detailed response info.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        protected async Task<IApiV2Response<TIdentifiableObject>> RequestGetWithResponseAsync<TIdentifiableObject, TId>(TId id, CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var (response, cache) = await this.GetOrUpdateAsync<TIdentifiableObject>(this.FormatUrlQueryItem(this.EndpointPath, id), id, cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestManyAsync<TIdentifiableObject, TId>(IEnumerable<TId> ids)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            this.RequestManyAsync<TIdentifiableObject, TId>(ids, CancellationToken.None);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestManyAsync<TIdentifiableObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            (await this.RequestManyWithResponseAsync<TIdentifiableObject, TId>(ids, cancellationToken).ConfigureAwait(false)).SelectMany(x => x.Content).ToList();

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        protected async Task<IReadOnlyList<IApiV2Response<IReadOnlyList<TIdentifiableObject>>>> RequestManyWithResponseAsync<TIdentifiableObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var responses = new List<ApiV2Response<IReadOnlyList<TIdentifiableObject>>>();
            object responsesLock = new object();

            var cache = await this.Connection.CacheMethod.GetOrUpdateManyAsync<TIdentifiableObject>(this.EndpointPath, ids.Cast<object>(),
                async missingIds =>
                {
                    var requestIds = new List<IEnumerable<object>>();
                    for (int i = 0; i < missingIds.Count; i += MaxPageSize)
                        requestIds.Add(missingIds.Skip(i).Take(MaxPageSize));

                    var latestCacheTime = DateTime.Now;
                    var result = await Task.WhenAll(requestIds.Select(async innerIds =>
                    {
                        var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, this.FormatUrlQueryMany(this.EndpointPath, innerIds)));
                        var httpResponse = await this.Connection.RequestAsync<IReadOnlyList<TIdentifiableObject>>(uri, cancellationToken).ConfigureAwait(false);
                        var response = new ApiV2Response<IReadOnlyList<TIdentifiableObject>>(httpResponse);
                        lock (responsesLock)
                        {
                            responses.Add(response);
                            if (response.Expires.HasValue && latestCacheTime < response.Expires)
                                latestCacheTime = response.Expires.Value;
                        }
                        return response.Content.ToDictionary(x => x.Id, x => x);
                    })).ConfigureAwait(false);

                    return (result.SelectMany(x => x).ToDictionary(kvp => (object)kvp.Key, kvp => kvp.Value), latestCacheTime);
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
        protected Task<IReadOnlyList<TIdentifiableObject>> RequestPageAsync<TIdentifiableObject, TId>(int page, int pageSize = MaxPageSize)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            this.RequestPageAsync<TIdentifiableObject, TId>(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IReadOnlyList<TIdentifiableObject>> RequestPageAsync<TIdentifiableObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object =>
            (await this.RequestPageWithResponseAsync<TIdentifiableObject, TId>(page, cancellationToken, pageSize).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IApiV2Response<IReadOnlyList<TIdentifiableObject>>> RequestPageWithResponseAsync<TIdentifiableObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object
        {
            pageSize = pageSize.Clamp(1, 200);

            var (response, cache) = await this.GetOrUpdateAsync<IReadOnlyList<TIdentifiableObject>>(this.FormatUrlQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividualsAsync<TIdentifiableObject, TId>(cache).ConfigureAwait(false);

            return new ApiV2Response<IReadOnlyList<TIdentifiableObject>>(response) { Content = cache.Item };
        }

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected Task<TObject> RequestPageAsync(int page, int pageSize = MaxPageSize) =>
            this.RequestPageAsync(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<TObject> RequestPageAsync(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize) =>
            (await this.RequestPageWithResponseAsync(page, cancellationToken, pageSize).ConfigureAwait(false)).Content;

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        protected async Task<IApiV2Response<TObject>> RequestPageWithResponseAsync(int page, CancellationToken cancellationToken, int pageSize = MaxPageSize)
        {
            pageSize = pageSize.Clamp(1, 200);

            var (response, _) = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            return response;
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
        /// <exception cref="ArgumentNullException"><paramref name="url"/> or <paramref name="cacheId"/> is <c>null</c>.</exception>
        protected async Task<(ApiV2Response<TIdentifiableObject>, CacheItem<TIdentifiableObject>)> GetOrUpdateAsync<TIdentifiableObject>(string url, object cacheId, CancellationToken cancellationToken)
            where TIdentifiableObject : object
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            if (cacheId == null)
                throw new ArgumentNullException(nameof(cacheId));

            ApiV2Response<TIdentifiableObject>? response = null;
            var result = await this.Connection.CacheMethod.GetOrUpdateAsync(this.EndpointPath, cacheId,
                async () =>
                {
                    var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, url));
                    var httpResponse = await this.Connection.RequestAsync<TIdentifiableObject>(uri, cancellationToken).ConfigureAwait(false);
                    response = new ApiV2Response<TIdentifiableObject>(httpResponse);
                    return (httpResponse.Content, response.Expires ?? DateTime.Now);
                }).ConfigureAwait(false);
            response ??= new ApiV2Response<TIdentifiableObject>(result.Item);
            return (response, result);
        }

        /// <summary>
        /// Helper function to update individual cache items from a many API request.
        /// </summary>
        /// <typeparam name="TIdentifiableObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <returns>The list of cached items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cache"/> is <c>null</c>.</exception>
        protected async Task<IReadOnlyList<CacheItem<TIdentifiableObject>>> UpdateIndividualsAsync<TIdentifiableObject, TId>(CacheItem<IReadOnlyList<TIdentifiableObject>> cache)
            where TIdentifiableObject : object, IIdentifiable<TId>
            where TId : object
        {
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));

            var cacheList = cache.Item.Select(x => new CacheItem<TIdentifiableObject>(this.EndpointPath, x.Id, x, cache.ExpiryTime)).ToList();
            await this.Connection.CacheMethod.SetManyAsync(cacheList).ConfigureAwait(false);
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
        protected virtual string FormatUrlQueryAll(string endpointPath) => $"{endpointPath}{QueryAll}";

        /// <summary>
        /// Formats a URL with querying ids.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryIds(string endpointPath) => endpointPath;

        /// <summary>
        /// Formats a URL with querying a blob of data.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryBlob(string endpointPath) => endpointPath;

        /// <summary>
        /// Formats a URL with querying an item.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="id">The item id.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryItem<T>(string endpointPath, T id) => $"{endpointPath}{string.Format(QueryItem, id)}";

        /// <summary>
        /// Formats a URL with querying many items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="ids">The item ids.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryMany<T>(string endpointPath, IEnumerable<T> ids) => $"{endpointPath}{string.Format(QueryMany, string.Join(",", ids))}";

        /// <summary>
        /// Formats a URL with querying a page of items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryPage(string endpointPath, int page, int pageSize) => $"{endpointPath}{string.Format(QueryPage, page, pageSize)}";

        /// <summary>
        /// Appends the parameters to the URI.
        /// The implementer is responsible for getting the parameters from the current this object.
        /// </summary>
        /// <param name="uri">The base URI.</param>
        /// <returns>The formatted URL.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
        protected virtual Uri AppendUrlParameters(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            var parameterProperties = this.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<EndpointPathParameterAttribute>() != null);

            if (parameterProperties.Count() == 0)
                return uri;

            var builder = new UriBuilder(uri);
            foreach (var parameter in parameterProperties)
            {
                var attr = parameter.GetCustomAttribute<EndpointPathParameterAttribute>();
                object value = parameter.GetValue(this);
                if (value == null)
                    continue;

                string toAppend = $"{attr.ParameterName}={Uri.EscapeDataString(value.ToString())}";
                builder.Query = builder.Query != null && builder.Query.Length > 1
                    ? $"{builder.Query.Substring(1)}&{toAppend}"
                    : toAppend;
            }
            return builder.Uri;
        }


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
