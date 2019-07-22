using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Render
{
    /// <summary>
    /// An interface for the client implementation of the Guild Wars 2 API render service.
    /// </summary>
    public interface IGw2WebApiRenderClient
    {
        /// <summary>
        /// Downloads a resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <returns>The task.</returns>
        Task DownloadToStreamAsync(Stream targetStream, string renderUrl);

        /// <summary>
        /// Downloads a resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <returns>The task.</returns>
        Task DownloadToStreamAsync(Stream targetStream, Uri renderUrl);

        /// <summary>
        /// Downloads a resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task DownloadToStreamAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads a resource from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task DownloadToStreamAsync(Stream targetStream, Uri renderUrl, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads a resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <returns>The task with the resource as byte array.</returns>
        Task<byte[]> DownloadToByteArrayAsync(string renderUrl);

        /// <summary>
        /// Downloads a resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <returns>The task with the resource as byte array.</returns>
        Task<byte[]> DownloadToByteArrayAsync(Uri renderUrl);

        /// <summary>
        /// Downloads a resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task with the resource as byte array.</returns>
        Task<byte[]> DownloadToByteArrayAsync(string renderUrl, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads a resource from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The resource render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task with the resource as byte array.</returns>
        Task<byte[]> DownloadToByteArrayAsync(Uri renderUrl, CancellationToken cancellationToken);
    }
}
