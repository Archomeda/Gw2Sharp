using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointClient<TObject> : BaseClient, IEndpointClient
        where TObject : IApiV2Object
    {
        private const int MAX_PAGE_SIZE = 200;

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        protected BaseEndpointClient(IConnection connection) :
            base(connection)
        {
            this.EndpointPath = this.GetRequiredAttribute<EndpointPathAttribute>().EndpointPath;
            this.SchemaVersion = this.GetAttribute<EndpointSchemaVersionAttribute>()?.SchemaVersion;

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
        protected BaseEndpointClient(IConnection connection, params string[] replaceSegments) :
            this(connection)
        {
            var segments = this.GetRequiredAttributes<EndpointPathSegmentAttribute>().OrderBy(a => a.Order).ToList();
            if (segments.Count != replaceSegments.Length)
                throw new InvalidOperationException($"The defined amount of path segments ({segments.Count}) does not equal to the passed amount of replacement segments ({replaceSegments.Length})");

            for (int i = 0; i < segments.Count; i++)
                this.EndpointPath = this.EndpointPath.Replace($":{segments[i].PathSegment}", replaceSegments[i]);
        }


        #region Properties

        /// <inheritdoc />
        public string EndpointPath { get; }

        /// <inheritdoc />
        public string? SchemaVersion { get; }


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

        #endregion


        #region Request Methods

        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>All entries.</returns>
        protected Task<IApiV2ObjectList<TEndpointObject>> RequestAllAsync<TEndpointObject, TId>()
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object =>
            this.RequestAllAsync<TEndpointObject, TId>(CancellationToken.None);

        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        protected async Task<IApiV2ObjectList<TEndpointObject>> RequestAllAsync<TEndpointObject, TId>(CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            var items = await this.GetOrUpdateAsync<IApiV2ObjectList<TEndpointObject>>(this.FormatUrlQueryAll(this.EndpointPath), "_all", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividualsAsync<TEndpointObject, TId>(items).ConfigureAwait(false);
            return items.Item;
        }

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <returns>Entry ids.</returns>
        protected Task<IApiV2ObjectList<TId>> RequestIdsAsync<TId>() =>
            this.RequestIdsAsync<TId>(CancellationToken.None);

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        protected async Task<IApiV2ObjectList<TId>> RequestIdsAsync<TId>(CancellationToken cancellationToken)
        {
            var ids = await this.GetOrUpdateAsync<IApiV2ObjectList<TId>>(this.FormatUrlQueryIds(this.EndpointPath), "_ids", cancellationToken).ConfigureAwait(false);
            return ids.Item;
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
        protected async Task<TObject> RequestGetAsync(CancellationToken cancellationToken)
        {
            var @object = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryBlob(this.EndpointPath), "_index", cancellationToken).ConfigureAwait(false);
            return @object.Item;
        }

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        protected Task<TEndpointObject> RequestGetAsync<TEndpointObject, TId>(TId id)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object =>
            this.RequestGetAsync<TEndpointObject, TId>(id, CancellationToken.None);

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        protected Task<TEndpointObject> RequestGetAsync<TEndpointObject, TId>(TId id, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.RequestGetInternalAsync<TEndpointObject, TId>(id, cancellationToken);
        }

        private async Task<TEndpointObject> RequestGetInternalAsync<TEndpointObject, TId>(TId id, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            var @object = await this.GetOrUpdateAsync<TEndpointObject>(this.FormatUrlQueryItem(this.EndpointPath, id), id, cancellationToken).ConfigureAwait(false);
            return @object.Item;
        }

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        protected Task<IReadOnlyList<TEndpointObject>> RequestManyAsync<TEndpointObject, TId>(IEnumerable<TId> ids)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object =>
            this.RequestManyAsync<TEndpointObject, TId>(ids, CancellationToken.None);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        protected Task<IReadOnlyList<TEndpointObject>> RequestManyAsync<TEndpointObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return this.RequestManyInternalAsync<TEndpointObject, TId>(ids, cancellationToken);
        }

        private async Task<IReadOnlyList<TEndpointObject>> RequestManyInternalAsync<TEndpointObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            object lockObject = new object();

            var cache = await this.Connection.CacheMethod.GetOrUpdateManyAsync<TEndpointObject>(this.EndpointPath, ids.Cast<object>(), async missingIds =>
            {
                var partitions = Partitioner.Create(0, missingIds.Count, MAX_PAGE_SIZE).GetDynamicPartitions();
                var latestCacheTime = DateTime.Now;

                var result = await Task.WhenAll(partitions.Select(async partition =>
                {
                    var (start, end) = partition;
                    var pageIds = missingIds.Skip(start).Take(end - start);

                    var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, this.FormatUrlQueryMany(this.EndpointPath, pageIds)));
                    var headers = this.BuildRequestHeaders();
                    var httpResponse = await this.Connection.RequestAsync<IApiV2ObjectList<TEndpointObject>>(uri, headers, cancellationToken).ConfigureAwait(false);

                    var @object = httpResponse.Content;
                    @object.HttpResponseInfo = new ApiV2HttpResponseInfo(httpResponse.StatusCode, httpResponse.RequestHeaders, httpResponse.ResponseHeaders);

                    lock (lockObject)
                    {
                        if (@object.HttpResponseInfo.Expires.HasValue && latestCacheTime < @object.HttpResponseInfo.Expires)
                            latestCacheTime = @object.HttpResponseInfo.Expires.Value;
                    }

                    return @object.ToDictionary(x => x.Id, x => x);
                })).ConfigureAwait(false);

                return (result.SelectMany(x => x).ToDictionary(kvp => (object)kvp.Key, kvp => kvp.Value), latestCacheTime);
            }).ConfigureAwait(false);

            var items = cache.Select(x => x.Item).ToList();
            return items.AsReadOnly();
        }

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        protected Task<IApiV2ObjectList<TEndpointObject>> RequestPageAsync<TEndpointObject, TId>(int page, int pageSize = MAX_PAGE_SIZE)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object =>
            this.RequestPageAsync<TEndpointObject, TId>(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        protected Task<IApiV2ObjectList<TEndpointObject>> RequestPageAsync<TEndpointObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MAX_PAGE_SIZE)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            if (pageSize < 1 || pageSize > 200)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size cannot be smaller than 1 or bigger than 200");

            return this.RequestPageInternalAsync<TEndpointObject, TId>(page, cancellationToken, pageSize);
        }

        private async Task<IApiV2ObjectList<TEndpointObject>> RequestPageInternalAsync<TEndpointObject, TId>(int page, CancellationToken cancellationToken, int pageSize = MAX_PAGE_SIZE)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            var items = await this.GetOrUpdateAsync<IApiV2ObjectList<TEndpointObject>>(this.FormatUrlQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividualsAsync<TEndpointObject, TId>(items).ConfigureAwait(false);
            return items.Item;
        }

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        protected Task<TObject> RequestPageAsync(int page, int pageSize = MAX_PAGE_SIZE) =>
            this.RequestPageAsync(page, CancellationToken.None, pageSize);

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        protected Task<TObject> RequestPageAsync(int page, CancellationToken cancellationToken, int pageSize = MAX_PAGE_SIZE)
        {
            if (pageSize < 1 || pageSize > 200)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size cannot be smaller than 1 or bigger than 200");

            return this.RequestPageInternalAsync(page, cancellationToken, pageSize);
        }

        private async Task<TObject> RequestPageInternalAsync(int page, CancellationToken cancellationToken, int pageSize = MAX_PAGE_SIZE)
        {
            var items = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryPage(this.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            return items.Item;
        }

        #endregion


        #region Protected Request Methods

        /// <summary>
        /// A helper function that makes an API request for items that do not exist in the cache.
        /// Non-expired items in the cache are skipped for requests and are taken from the cache instead.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <param name="url">The request URL.</param>
        /// <param name="cacheId">The cache identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The previously cached response, or a newly requested response that's been cached.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="url"/> or <paramref name="cacheId"/> is <c>null</c>.</exception>
        protected Task<CacheItem<TEndpointObject>> GetOrUpdateAsync<TEndpointObject>(string url, object cacheId, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));
            if (cacheId == null)
                throw new ArgumentNullException(nameof(cacheId));

            return this.GetOrUpdateInternalAsync<TEndpointObject>(url, cacheId, cancellationToken);
        }

        private async Task<CacheItem<TEndpointObject>> GetOrUpdateInternalAsync<TEndpointObject>(string url, object cacheId, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object
        {
            if (this.IsAuthenticated)
            {
                // Prepend the cache id with a hash of the access token to make sure that different access tokens will get separately cached
                cacheId = $"{this.Connection.AccessToken.GetSha1Hash()}_{cacheId}";
            }

            var result = await this.Connection.CacheMethod.GetOrUpdateAsync(this.EndpointPath, cacheId, async () =>
            {
                var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, url));
                var headers = this.BuildRequestHeaders();
                var httpResponse = await this.Connection.RequestAsync<TEndpointObject>(uri, headers, cancellationToken).ConfigureAwait(false);

                var @object = httpResponse.Content;
                @object.HttpResponseInfo = new ApiV2HttpResponseInfo(httpResponse.StatusCode, httpResponse.RequestHeaders, httpResponse.ResponseHeaders);
                return (@object, @object.HttpResponseInfo.Expires ?? DateTime.Now);
            }).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Helper function to update individual cache items from a many API request.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="cache">The cache.</param>
        /// <returns>The list of cached items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="cache"/> is <c>null</c>.</exception>
        protected Task<IReadOnlyList<CacheItem<TEndpointObject>>> UpdateIndividualsAsync<TEndpointObject, TId>(CacheItem<IApiV2ObjectList<TEndpointObject>> cache)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));

            return this.UpdateIndividualsInternalAsync<TEndpointObject, TId>(cache);
        }

        private async Task<IReadOnlyList<CacheItem<TEndpointObject>>> UpdateIndividualsInternalAsync<TEndpointObject, TId>(CacheItem<IApiV2ObjectList<TEndpointObject>> cache)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : object
        {
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));

            var cacheList = cache.Item.Select(x => new CacheItem<TEndpointObject>(this.EndpointPath, x.Id, x, cache.ExpiryTime)).ToList();
            await this.Connection.CacheMethod.SetManyAsync(cacheList).ConfigureAwait(false);
            return cacheList;
        }

        #endregion


        #region Formatters

        private const string QUERY_ALL = "?ids=all";
        private const string QUERY_ITEM = "/{0}";
        private const string QUERY_MANY = "?ids={0}";
        private const string QUERY_PAGE = "?page={0}&page_size={1}";

        /// <summary>
        /// Formats a URL with querying all items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryAll(string endpointPath) =>
            $"{endpointPath}{QUERY_ALL}";

        /// <summary>
        /// Formats a URL with querying ids.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryIds(string endpointPath) =>
            endpointPath;

        /// <summary>
        /// Formats a URL with querying a blob of data.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryBlob(string endpointPath) =>
            endpointPath;

        /// <summary>
        /// Formats a URL with querying an item.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="id">The item id.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryItem<T>(string endpointPath, T id) =>
            $"{endpointPath}{string.Format(QUERY_ITEM, id)}";

        /// <summary>
        /// Formats a URL with querying many items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="ids">The item ids.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryMany<T>(string endpointPath, IEnumerable<T> ids) =>
            $"{endpointPath}{string.Format(QUERY_MANY, string.Join(",", ids))}";

        /// <summary>
        /// Formats a URL with querying a page of items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryPage(string endpointPath, int page, int pageSize) =>
            $"{endpointPath}{string.Format(QUERY_PAGE, page, pageSize)}";

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


        /// <summary>
        /// Builds additional request headers for this endpoint.
        /// </summary>
        /// <returns>The request headers.</returns>
        protected virtual IDictionary<string, string> BuildRequestHeaders()
        {
            var headers = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(this.SchemaVersion))
                headers.Add("X-Schema-Version", this.SchemaVersion);
            return headers;
        }

        #endregion


        #region Reflection Helpers

        private bool ImplementsInterface(Type interfaceType) =>
            this.GetType().GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == interfaceType);

        private T GetRequiredAttribute<T>() where T : Attribute =>
            this.GetRequiredAttributes<T>().First();

        private IReadOnlyList<T> GetRequiredAttributes<T>() where T : Attribute
        {
            var attrs = this.GetAttributes<T>();
            if (attrs.Count == 0)
                throw new InvalidOperationException($"{this.GetType().FullName} is required to define one or more attributes of {typeof(T).FullName}");
            return attrs;
        }

        private T? GetAttribute<T>() where T : Attribute =>
            this.GetAttributes<T>().FirstOrDefault();

        private IReadOnlyList<T> GetAttributes<T>() where T : Attribute =>
            this.GetType().GetCustomAttributes<T>().ToList();

        #endregion
    }
}
