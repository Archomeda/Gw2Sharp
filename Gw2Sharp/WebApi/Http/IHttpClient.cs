using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a custom HTTP client.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// The timeout for every request.
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
        /// <exception cref="UnexpectedStatusException">Thrown when the server returns a non-successful HTTP status code.</exception>
        Task<IHttpResponse> RequestAsync(IHttpRequest request, CancellationToken cancellationToken);
    }
}
