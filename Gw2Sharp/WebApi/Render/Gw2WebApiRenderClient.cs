using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// A client for the Guild Wars 2 API render service.
    /// </summary>
    public class Gw2WebApiRenderClient : IGw2WebApiRenderClient
    {
        private const string CACHE_CATEGORY = "render";
        private readonly IConnection connection;

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
            this.connection = connection;
        }


        private Task<CacheItem<byte[]>> DownloadImageToCacheAsync(string renderUrl, CancellationToken cancellationToken)
        {
            return this.connection.RenderCacheMethod.GetOrUpdateAsync<byte[]>(CACHE_CATEGORY, renderUrl, async () =>
            {
                var request = new HttpRequest(new Uri(renderUrl));
                var response = await this.connection.HttpClient.RequestStreamAsync(request, cancellationToken).ConfigureAwait(false);

                using var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream).ConfigureAwait(false);
                var responseInfo = new HttpResponseInfo(response.StatusCode, response.RequestHeaders, response.ResponseHeaders);
                return (memoryStream.ToArray(), responseInfo.Expires ?? responseInfo.Date + responseInfo.CacheMaxAge ?? DateTimeOffset.Now);
            });
        }


        /// <inheritdoc />
        public virtual Task DownloadImageToStreamAsync(Stream targetStream, string renderUrl) =>
            this.DownloadImageToStreamAsync(targetStream, renderUrl, CancellationToken.None);

        /// <inheritdoc />
        public virtual Task DownloadImageToStreamAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken)
        {
            if (targetStream == null)
                throw new ArgumentNullException(nameof(targetStream));
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
#pragma warning disable S2583 // Conditionally executed blocks should be reachable - false positive in SonarCloud
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
#pragma warning restore S2583 // Conditionally executed blocks should be reachable

            return this.DownloadImageToStreamInternalAsync(targetStream, renderUrl, cancellationToken);
        }

        private async Task DownloadImageToStreamInternalAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken)
        {
            var cacheItem = await this.DownloadImageToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
            using var memoryStream = new MemoryStream(cacheItem.Item, false);
            await memoryStream.CopyToAsync(targetStream).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public virtual Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl) =>
            this.DownloadImageToByteArrayAsync(renderUrl, CancellationToken.None);

        /// <inheritdoc />
        public virtual Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl, CancellationToken cancellationToken)
        {
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
#pragma warning disable S2583 // Conditionally executed blocks should be reachable - false positive in SonarCloud
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
#pragma warning restore S2583 // Conditionally executed blocks should be reachable

            return this.DownloadImageToByteArrayInternalAsync(renderUrl, cancellationToken);
        }

        private async Task<byte[]> DownloadImageToByteArrayInternalAsync(string renderUrl, CancellationToken cancellationToken)
        {
            var cacheItem = await this.DownloadImageToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
            using var memoryStream = new MemoryStream(cacheItem.Item, false);
            return memoryStream.ToArray();
        }
    }
}