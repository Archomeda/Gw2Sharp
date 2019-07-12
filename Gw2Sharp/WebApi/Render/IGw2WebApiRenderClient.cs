using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for the client implementation of the Guild Wars 2 API render service.
    /// </summary>
    public interface IGw2WebApiRenderClient
    {
        /// <summary>
        /// Downloads an image from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The image render URL.</param>
        /// <returns>The task.</returns>
        Task DownloadImageToStreamAsync(Stream targetStream, string renderUrl);

        /// <summary>
        /// Downloads an image from the render service to a stream asynchronously.
        /// </summary>
        /// <param name="targetStream">The target stream.</param>
        /// <param name="renderUrl">The image render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task.</returns>
        Task DownloadImageToStreamAsync(Stream targetStream, string renderUrl, CancellationToken cancellationToken);

        /// <summary>
        /// Downloads an image from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The image render URL.</param>
        /// <returns>The task with the image as byte array.</returns>
        Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl);

        /// <summary>
        /// Downloads an image from the render service to a byte array asynchronously.
        /// </summary>
        /// <param name="renderUrl">The image render URL.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The task with the image as byte array.</returns>
        Task<byte[]> DownloadImageToByteArrayAsync(string renderUrl, CancellationToken cancellationToken);
    }
}
