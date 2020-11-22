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
    public class Gw2WebApiRenderClient : Gw2WebApiBaseClient, IGw2WebApiRenderClient
    {
        private const string CACHE_CATEGORY = "render";

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiRenderClient"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal Gw2WebApiRenderClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (gw2Client == null)
                throw new ArgumentNullException(nameof(gw2Client));
        }


        private Task<CacheItem> DownloadToCacheAsync(string renderUrl, CancellationToken cancellationToken) =>
            this.Connection.RenderCacheMethod.GetOrUpdateAsync(CACHE_CATEGORY, renderUrl, async (cacheCategory, cacheId) =>
            {
                var request = new WebApiRequest(new Uri(renderUrl), this.Connection, this.Gw2Client);
                using var response = await this.Connection.HttpClient.RequestStreamAsync(request, cancellationToken).ConfigureAwait(false);

#if NETSTANDARD
                using var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream).ConfigureAwait(false);
#else
                await using var memoryStream = new MemoryStream();
                await response.ContentStream.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
#endif
                var responseInfo = new HttpResponseInfo(response.StatusCode, response.ResponseHeaders);
                return new CacheItem(cacheCategory, cacheId, memoryStream.ToArray(), response.StatusCode,
                    responseInfo.Expires ?? (responseInfo.Date + responseInfo.CacheMaxAge) ?? DateTimeOffset.Now, CacheItemStatus.New);
            });


        /// <inheritdoc />
        public Task DownloadToStreamAsync(Stream targetStream, Uri renderUrl, CancellationToken cancellationToken = default)
        {
            if (targetStream == null)
                throw new ArgumentNullException(nameof(targetStream));
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));

            return this.DownloadToStreamAsync(targetStream, renderUrl.AbsoluteUri, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task DownloadToStreamAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken = default)
        {
            if (targetStream == null)
                throw new ArgumentNullException(nameof(targetStream));
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
            return ExecAsync();

            async Task ExecAsync()
            {
                var cacheItem = await this.DownloadToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
#if NETSTANDARD
                using var memoryStream = new MemoryStream(cacheItem.RawItem, false);
                await memoryStream.CopyToAsync(targetStream).ConfigureAwait(false);
#else
                await using var memoryStream = new MemoryStream(cacheItem.RawItem, false);
                await memoryStream.CopyToAsync(targetStream, cancellationToken).ConfigureAwait(false);
#endif
            }
        }


        /// <inheritdoc />
        public Task<byte[]> DownloadToByteArrayAsync(Uri renderUrl, CancellationToken cancellationToken = default)
        {
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));

            return this.DownloadToByteArrayAsync(renderUrl.AbsoluteUri, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task<byte[]> DownloadToByteArrayAsync(string renderUrl, CancellationToken cancellationToken = default)
        {
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may not be empty or only contain whitespaces", nameof(renderUrl));
            return ExecAsync();

            async Task<byte[]> ExecAsync()
            {
                var cacheItem = await this.DownloadToCacheAsync(renderUrl, cancellationToken).ConfigureAwait(false);
#if NETSTANDARD
                using var memoryStream = new MemoryStream(cacheItem.RawItem, false);
                return memoryStream.ToArray();
#else
                await using var memoryStream = new MemoryStream(cacheItem.RawItem, false);
                return memoryStream.ToArray();
#endif
            }
        }
    }
}
