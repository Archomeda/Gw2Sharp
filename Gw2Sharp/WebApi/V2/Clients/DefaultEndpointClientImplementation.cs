using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A class that contains default endpoint client implementations.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public class DefaultEndpointClientImplementation<TObject> : IEndpointClientImplementation<TObject>
        where TObject : IApiV2Object
    {
        internal const int MAX_PAGE_SIZE = 200;

        private readonly IEndpointClient client;

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="client">The endpoint client.</param>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/>, <paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        public DefaultEndpointClientImplementation(IEndpointClient client, IConnection connection, IGw2Client gw2Client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.Gw2Client = gw2Client ?? throw new ArgumentNullException(nameof(gw2Client));
        }

        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        protected IConnection Connection { get; }

        /// <summary>
        /// Gets the Guild Wars 2 client.
        /// </summary>
        protected IGw2Client Gw2Client { get; set; }


        #region Request Methods

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TEndpointObject>> RequestAllAsync<TEndpointObject, TId>(CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            var items = await this.GetOrUpdateAsync<IApiV2ObjectList<TEndpointObject>>(this.FormatUrlQueryAll(this.client.EndpointPath), "_all", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividualsAsync<TEndpointObject, TId>(items).ConfigureAwait(false);
            return items.Item;
        }

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TId>> RequestIdsAsync<TId>(CancellationToken cancellationToken = default)
        {
            var ids = await this.GetOrUpdateAsync<IApiV2ObjectList<TId>>(this.FormatUrlQueryIds(this.client.EndpointPath), "_ids", cancellationToken).ConfigureAwait(false);
            return ids.Item;
        }

        /// <inheritdoc />
        public virtual async Task<TObject> RequestGetAsync(CancellationToken cancellationToken = default)
        {
            var @object = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryBlob(this.client.EndpointPath), "_index", cancellationToken).ConfigureAwait(false);
            return @object.Item;
        }

        /// <inheritdoc />
        public virtual Task<TEndpointObject> RequestGetAsync<TEndpointObject, TId>(TId id, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.RequestGetInternalAsync<TEndpointObject, TId>(id, cancellationToken);
        }

        private async Task<TEndpointObject> RequestGetInternalAsync<TEndpointObject, TId>(TId id, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            var @object = await this.GetOrUpdateAsync<TEndpointObject>(this.FormatUrlQueryItem(this.client.EndpointPath, id), id!, cancellationToken).ConfigureAwait(false);
            return @object.Item;
        }

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TEndpointObject>> RequestManyAsync<TEndpointObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return this.RequestManyInternalAsync<TEndpointObject, TId>(ids, cancellationToken);
        }

        private async Task<IReadOnlyList<TEndpointObject>> RequestManyInternalAsync<TEndpointObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            object lockObject = new object();

            var cache = await this.Connection.CacheMethod.GetOrUpdateManyAsync<TEndpointObject>(this.client.EndpointPath, ids.Cast<object>(), async missingIds =>
            {
                var partitions = Partitioner.Create(0, missingIds.Count, MAX_PAGE_SIZE).GetDynamicPartitions();
                var latestCacheTime = DateTimeOffset.Now;

                var result = await Task.WhenAll(partitions.Select(async partition =>
                {
                    var (start, end) = partition;
                    var pageIds = missingIds.Skip(start).Take(end - start);

                    var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, this.FormatUrlQueryMany(this.client.EndpointPath, pageIds)));
                    var headers = this.BuildRequestHeaders(this.client.SchemaVersion);
                    // No NullReferenceException possible for this.Gw2Client: our constructor enforces a value
                    var httpResponse = await this.Connection.RequestAsync<IApiV2ObjectList<TEndpointObject>>(this.Gw2Client!, uri, headers, cancellationToken).ConfigureAwait(false);

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

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TEndpointObject>> RequestPageAsync<TEndpointObject, TId>(int page, int pageSize = MAX_PAGE_SIZE, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            if (pageSize < 1 || pageSize > MAX_PAGE_SIZE)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, $"Page size cannot be smaller than 1 or bigger than {MAX_PAGE_SIZE}");

            return this.RequestPageInternalAsync<TEndpointObject, TId>(page, pageSize, cancellationToken);
        }

        private async Task<IApiV2ObjectList<TEndpointObject>> RequestPageInternalAsync<TEndpointObject, TId>(int page, int pageSize, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            var items = await this.GetOrUpdateAsync<IApiV2ObjectList<TEndpointObject>>(this.FormatUrlQueryPage(this.client.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
            await this.UpdateIndividualsAsync<TEndpointObject, TId>(items).ConfigureAwait(false);
            return items.Item;
        }

        /// <inheritdoc />
        public virtual Task<TObject> RequestPageAsync(int page, int pageSize = MAX_PAGE_SIZE, CancellationToken cancellationToken = default)
        {
            if (pageSize < 1 || pageSize > MAX_PAGE_SIZE)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, $"Page size cannot be smaller than 1 or bigger than {MAX_PAGE_SIZE}");

            return this.RequestPageInternalAsync(page, pageSize, cancellationToken);
        }

        private async Task<TObject> RequestPageInternalAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var items = await this.GetOrUpdateAsync<TObject>(this.FormatUrlQueryPage(this.client.EndpointPath, page, pageSize), $"_page{page}-{pageSize}", cancellationToken).ConfigureAwait(false);
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
        protected virtual Task<CacheItem<TEndpointObject>> GetOrUpdateAsync<TEndpointObject>(string url, object cacheId, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object
        {
            if (url is null)
                throw new ArgumentNullException(nameof(url));
            if (cacheId is null)
                throw new ArgumentNullException(nameof(cacheId));

            return this.GetOrUpdateInternalAsync<TEndpointObject>(url, cacheId, cancellationToken);
        }

        private async Task<CacheItem<TEndpointObject>> GetOrUpdateInternalAsync<TEndpointObject>(string url, object cacheId, CancellationToken cancellationToken)
            where TEndpointObject : IApiV2Object
        {
            cacheId = this.FormatCacheId(cacheId);

            var result = await this.Connection.CacheMethod.GetOrUpdateAsync(this.client.EndpointPath, cacheId, async () =>
            {
                var uri = this.AppendUrlParameters(new Uri(Gw2WebApiV2Client.UrlBase, url));
                var headers = this.BuildRequestHeaders(this.client.SchemaVersion);
                // No NullReferenceException possible for this.Gw2Client: our constructor enforces a value
                var httpResponse = await this.Connection.RequestAsync<TEndpointObject>(this.Gw2Client!, uri, headers, cancellationToken).ConfigureAwait(false);

                var @object = httpResponse.Content;
                @object.HttpResponseInfo = new ApiV2HttpResponseInfo(httpResponse.StatusCode, httpResponse.RequestHeaders, httpResponse.ResponseHeaders);
                return (@object, @object.HttpResponseInfo.Expires ?? DateTimeOffset.Now);
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
        protected virtual Task<IReadOnlyList<CacheItem<TEndpointObject>>> UpdateIndividualsAsync<TEndpointObject, TId>(CacheItem<IApiV2ObjectList<TEndpointObject>> cache)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            if (cache is null)
                throw new ArgumentNullException(nameof(cache));

            return this.UpdateIndividualsInternalAsync<TEndpointObject, TId>(cache);
        }

        private async Task<IReadOnlyList<CacheItem<TEndpointObject>>> UpdateIndividualsInternalAsync<TEndpointObject, TId>(CacheItem<IApiV2ObjectList<TEndpointObject>> cache)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
        {
            var cacheList = cache.Item.Select(x => new CacheItem<TEndpointObject>(this.client.EndpointPath, x.Id!, x, cache.ExpiryTime)).ToList();
            await this.Connection.CacheMethod.SetManyAsync(cacheList).ConfigureAwait(false);
            return cacheList;
        }

        #endregion


        #region Formatters

        /// <summary>
        /// Formats the cache id with localization and authentication strings.
        /// </summary>
        /// <param name="cacheId">The original cache id.</param>
        /// <returns>The formatted cache id.</returns>
        protected internal virtual string FormatCacheId(object cacheId)
        {
            string prefixedCacheId = cacheId.ToString();

            if (this.client.IsLocalized)
            {
                // Prepend the cache id with the locale string to make sure that different locale requests will get separately cached
                prefixedCacheId = $"{this.Connection.LocaleString}_{prefixedCacheId}";
            }

            if (this.client.IsAuthenticated)
            {
                // Prepend the cache id with a hash of the access token to make sure that different access tokens will get separately cached
                prefixedCacheId = $"{this.Connection.AccessToken.GetSha1Hash()}_{prefixedCacheId}";
            }

            return prefixedCacheId;
        }


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
            $"{endpointPath}{string.Format(QUERY_ITEM, FormatId(id))}";

        /// <summary>
        /// Formats a URL with querying many items.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        /// <param name="ids">The item ids.</param>
        /// <returns>The formatted URL.</returns>
        protected virtual string FormatUrlQueryMany<T>(string endpointPath, IEnumerable<T> ids) =>
            $"{endpointPath}{string.Format(QUERY_MANY, string.Join(",", ids.Select(FormatId)))}";

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
            if (uri is null)
                throw new ArgumentNullException(nameof(uri));

            var parameters = this.client.EndpointPathParameters;
            if (!parameters.Any())
                return uri;

            var builder = new UriBuilder(uri);
            foreach (var parameter in parameters)
            {
                string toAppend = $"{parameter.Key}={Uri.EscapeDataString(parameter.Value)}";
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
        protected virtual IDictionary<string, string> BuildRequestHeaders(string? schemaVersion)
        {
            var headers = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(schemaVersion))
                headers.Add("X-Schema-Version", schemaVersion!);
            return headers;
        }

        private static string? FormatId<T>(T id)
        {
            return id switch
            {
                Guid guid => guid.ToString().ToUpperInvariant(),
                _ => id?.ToString(),
            };
        }

        #endregion
    }
}
