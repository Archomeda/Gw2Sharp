using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Render
{
    /// <summary>
    /// A client for the Guild Wars 2 API render service.
    /// </summary>
    public class Gw2WebApiRenderClient : IGw2WebApiRenderClient, IWebApiClientInternal
    {
        private const string CACHE_CATEGORY = "render";

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiRenderClient"/>.
        /// </summary>
        public Gw2WebApiRenderClient() : this(new Connection()) { }

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiRenderClient"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="NullReferenceException"><paramref name="connection"/> is <c>null</c>.</exception>
        public Gw2WebApiRenderClient(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }


        /// <inheritdoc />
        IConnection IWebApiClientInternal.Connection => this.Connection;

        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        internal IConnection Connection { get; }


        private Task<CacheItem<byte[]>> DownloadToCacheAsync(string renderUrl, CancellationToken cancellationToken)
        {
            return this.Connection.RenderCacheMethod.GetOrUpdateAsync<byte[]>(CACHE_CATEGORY, renderUrl, async () =>
            {
                var request = new HttpRequest(new Uri(renderUrl));
                var response = await this.Connection.HttpClient.RequestStreamAsync(request, cancellationToken).ConfigureAwait(false);

                using var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream).ConfigureAwait(false);
                var responseInfo = new HttpResponseInfo(response.StatusCode, response.RequestHeaders, response.ResponseHeaders);
                return (memoryStream.ToArray(), responseInfo.Expires ?? responseInfo.Date + responseInfo.CacheMaxAge ?? DateTimeOffset.Now);
            });
        }


        /// <inheritdoc />
        public virtual Task DownloadToStreamAsync(Stream targetStream, string renderUrl) =>
            this.DownloadToStreamAsync(targetStream, renderUrl, CancellationToken.None);

        /// <inheritdoc />
        public virtual Task DownloadToStreamAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken)
        {
            if (targetStream == null)
                throw new ArgumentNullException(nameof(targetStream));
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
#pragma warning disable S2583 // Conditionally executed blocks should be reachable - false positive in SonarCloud
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
#pragma warning restore S2583 // Conditionally executed blocks should be reachable

            return this.DownloadToStreamInternalAsync(targetStream, renderUrl, cancellationToken);
        }

        private async Task DownloadToStreamInternalAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken)
        {
            var cacheItem = await this.DownloadToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
            using var memoryStream = new MemoryStream(cacheItem.Item, false);
            await memoryStream.CopyToAsync(targetStream).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public virtual Task<byte[]> DownloadToByteArrayAsync(string renderUrl) =>
            this.DownloadToByteArrayAsync(renderUrl, CancellationToken.None);

        /// <inheritdoc />
        public virtual Task<byte[]> DownloadToByteArrayAsync(string renderUrl, CancellationToken cancellationToken)
        {
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
#pragma warning disable S2583 // Conditionally executed blocks should be reachable - false positive in SonarCloud
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
#pragma warning restore S2583 // Conditionally executed blocks should be reachable

            return this.DownloadToByteArrayInternalAsync(renderUrl, cancellationToken);
        }

        private async Task<byte[]> DownloadToByteArrayInternalAsync(string renderUrl, CancellationToken cancellationToken)
        {
            var cacheItem = await this.DownloadToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
            using var memoryStream = new MemoryStream(cacheItem.Item, false);
            return memoryStream.ToArray();
        }
    }
}
