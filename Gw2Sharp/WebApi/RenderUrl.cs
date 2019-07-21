using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Render;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// Represents a URL to a resource on the Guild Wars 2 render service API.
    /// </summary>
    public struct RenderUrl : IEquatable<RenderUrl>
    {
        private readonly IGw2WebApiRenderClient renderClient;

        /// <summary>
        /// Creates a new <see cref="RenderUrl"/>.
        /// </summary>
        /// <param name="renderClient">The web render client.</param>
        /// <param name="url">The URL to a resource on the Guild Wars 2 render service API.</param>
        internal RenderUrl(IGw2WebApiRenderClient renderClient, string url)
        {
            this.renderClient = renderClient;
            this.Url = url;
        }


        /// <summary>
        /// The URL to a resource on the Guild Wars 2 render service API.
        /// </summary>
        public string Url { get; }


        /// <inheritdoc />
        public override string ToString() =>
            this.Url;


        #region IGw2WebApiRenderClient

        /// <summary>
        /// Downloads the resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <returns>The task.</returns>
        public Task DownloadToStreamAsync(Stream targetStream) =>
            this.renderClient.DownloadToStreamAsync(targetStream, this.Url);

        /// <summary>
        /// Downloads the resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        public Task DownloadToStreamAsync(Stream targetStream, CancellationToken cancellationToken) =>
            this.renderClient.DownloadToStreamAsync(targetStream, this.Url, cancellationToken);

        /// <summary>
        /// Downloads the resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <returns>The task with the resource as byte array.</returns>
        public Task<byte[]> DownloadToByteArrayAsync() =>
            this.renderClient.DownloadToByteArrayAsync(this.Url);

        /// <summary>
        /// Downloads the resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task with the resource as byte array.</returns>
        public Task<byte[]> DownloadToByteArrayAsync(CancellationToken cancellationToken) =>
            this.renderClient.DownloadToByteArrayAsync(this.Url, cancellationToken);

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
            -1915121810 + EqualityComparer<string>.Default.GetHashCode(this.Url);

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
            renderUrl.Url;

        #endregion
    }
}
