using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// Represents a URL to a resource on the Guild Wars 2 render service API.
    /// </summary>
    public struct RenderUrl : IEquatable<RenderUrl>
    {
        private const string RENDER_BASE_URL = "https://render.guildwars2.com";

        internal IGw2Client Gw2Client { get; set; }

        private readonly string renderPath;

        /// <summary>
        /// Creates a new <see cref="RenderUrl"/>.
        /// </summary>
        /// <param name="client">The Guild Wars 2 client.</param>
        /// <param name="url">The URL to a resource on the Guild Wars 2 render service API.</param>
        internal RenderUrl(IGw2Client client, string url)
        {
            this.Gw2Client = client;
            this.renderPath = new Uri(url, UriKind.Absolute).AbsolutePath;
        }


        /// <summary>
        /// The URL to a resource on the Guild Wars 2 render service API.
        /// </summary>
        public Uri Url => new Uri(new Uri(RENDER_BASE_URL), this.renderPath);


        /// <inheritdoc />
        public override string ToString() =>
            this.Url.AbsoluteUri;


        #region IGw2WebApiRenderClient

        /// <summary>
        /// Downloads the resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <returns>The task.</returns>
        public Task DownloadToStreamAsync(Stream targetStream) =>
            this.Gw2Client.WebApi.Render.DownloadToStreamAsync(targetStream, this.Url);

        /// <summary>
        /// Downloads the resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        public Task DownloadToStreamAsync(Stream targetStream, CancellationToken cancellationToken) =>
            this.Gw2Client.WebApi.Render.DownloadToStreamAsync(targetStream, this.Url, cancellationToken);

        /// <summary>
        /// Downloads the resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <returns>The task with the resource as byte array.</returns>
        public Task<byte[]> DownloadToByteArrayAsync() =>
            this.Gw2Client.WebApi.Render.DownloadToByteArrayAsync(this.Url);

        /// <summary>
        /// Downloads the resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task with the resource as byte array.</returns>
        public Task<byte[]> DownloadToByteArrayAsync(CancellationToken cancellationToken) =>
            this.Gw2Client.WebApi.Render.DownloadToByteArrayAsync(this.Url, cancellationToken);

        #endregion


        #region Equality overrides

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is RenderUrl renderUrl && this.Equals(renderUrl);

        /// <inheritdoc />
        public bool Equals(RenderUrl other) =>
            this.Url == other.Url;

        /// <inheritdoc />
        public override int GetHashCode() =>
            -1915121810 + EqualityComparer<Uri>.Default.GetHashCode(this.Url);

        #endregion


        #region Operators

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="RenderUrl"/>.</param>
        /// <param name="right">The second <see cref="RenderUrl"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RenderUrl left, RenderUrl right) =>
            EqualityComparer<RenderUrl>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="RenderUrl"/>.</param>
        /// <param name="right">The second <see cref="RenderUrl"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RenderUrl left, RenderUrl right) =>
            !(left == right);

        /// <summary>
        /// Gets the URL as string.
        /// </summary>
        /// <param name="renderUrl">The render URL object.</param>
        public static implicit operator string(RenderUrl renderUrl) =>
            renderUrl.Url.AbsoluteUri;

        /// <summary>
        /// Gets the URL as <see cref="Uri"/>.
        /// </summary>
        /// <param name="renderUrl">The render URL object.</param>
        public static implicit operator Uri(RenderUrl renderUrl) =>
            new Uri(renderUrl.Url.AbsoluteUri, UriKind.Absolute);

        #endregion
    }
}
