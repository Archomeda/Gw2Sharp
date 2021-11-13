using System;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Exceptions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a custom HTTP client.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// The timeout for every request.
        /// If <see cref="TimeSpan.Zero"/> or less, the default timeout is used (in case of <see cref="System.Net.Http.HttpClient"/>,
        /// this is 100 seconds; see <seealso cref="System.Net.Http.HttpClient.Timeout"/>).
        /// This value can be <see cref="Timeout.InfiniteTimeSpan"/> to have no timeout.
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Sends a request and returns a response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Used to cancel the request.</param>
        /// <returns>The web response.</returns>
        /// <exception cref="RequestException">Thrown when a generic request error occurs.</exception>
        /// <exception cref="RequestCanceledException">Thrown when the request is canceled by the user or because of a timeout.</exception>
        Task<IWebApiResponse> RequestAsync(IWebApiRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a request and returns a response stream.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">Used to cancel the request.</param>
        /// <returns>The web response stream.</returns>
        /// <exception cref="RequestException">Thrown when a generic request error occurs.</exception>
        /// <exception cref="RequestCanceledException">Thrown when the request is canceled by the user or because of a timeout.</exception>
        Task<IHttpResponseStream> RequestStreamAsync(IWebApiRequest request, CancellationToken cancellationToken = default);
    }
}
