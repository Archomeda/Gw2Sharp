using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Exceptions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a web API request.
    /// </summary>
    public interface IWebApiRequest
    {
        /// <summary>
        /// The request options.
        /// </summary>
        WebApiRequestOptions Options { get; }

        /// <summary>
        /// Performs a deep clone of the request.
        /// </summary>
        /// <returns>The cloned request.</returns>
        IWebApiRequest DeepCopy();

        /// <summary>
        /// Requests data from the API.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response with the object as the requested response type.</returns>
        /// <exception cref="RequestException">A generic request error occurs (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="RequestCanceledException">The request is canceled by the user or because of a timeout (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="UnexpectedStatusException">The server returns a non-successful HTTP status code (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        Task<IWebApiResponse<TResponse>> ExecuteAsync<TResponse>(CancellationToken cancellationToken = default);
    }
}
