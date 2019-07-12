using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// A client for the Guild Wars 2 API render service.
    /// </summary>
    public class Gw2WebApiRenderClient : IGw2WebApiRenderClient
    {
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
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may be empty", nameof(renderUrl));

            return this.DownloadImageToStreamInternalAsync(targetStream, renderUrl, cancellationToken);
        }

        private async Task DownloadImageToStreamInternalAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken)
        {
            var request = new HttpRequest(new Uri(renderUrl));
            var response = await this.connection.HttpClient.RequestStreamAsync(request, cancellationToken).ConfigureAwait(false);
            await response.ContentStream.CopyToAsync(targetStream).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl) =>
            this.DownloadImageToByteArrayAsync(renderUrl, CancellationToken.None);

        /// <inheritdoc />
        public virtual Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl, CancellationToken cancellationToken)
        {
            if (renderUrl == null)
                throw new ArgumentNullException(nameof(renderUrl));
            if (string.IsNullOrWhiteSpace(renderUrl))
                throw new ArgumentException("Render URL may be empty", nameof(renderUrl));

            return this.DownloadImageToByteArrayInternalAsync(renderUrl, cancellationToken);
        }

        private async Task<byte[]> DownloadImageToByteArrayInternalAsync(string renderUrl, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await this.DownloadImageToStreamInternalAsync(memoryStream, renderUrl, cancellationToken).ConfigureAwait(false);
            return memoryStream.ToArray();
        }
    }
}
