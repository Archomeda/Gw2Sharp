using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// Implements a web connection.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// The API key used for the API requests.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// The locale used for the API requests.
        /// </summary>
        Locale Locale { get; }

        /// <summary>
        /// The locale used for the API requests as lang value.
        /// </summary>
        string LocaleString { get; }

        /// <summary>
        /// The User-Agent used to make requests.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Gets the HTTP client that's used for the API requests.
        /// </summary>
        IHttpClient HttpClient { get; }

        /// <summary>
        /// Gets the cache controller that's used for API requests.
        /// </summary>
        ICacheMethod CacheMethod { get; }

        /// <summary>
        /// Requests data from the API.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="requestUri">The request Uri.</param>
        /// <param name="additionalHeaders">Additional request headers.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response with the object as the requested response type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="requestUri"/> is <c>null</c>.</exception>
        /// <exception cref="RequestException">A generic request error occurs (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="RequestCanceledException">The request is canceled by the user or because of a timeout (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="UnexpectedStatusException">The server returns a non-successful HTTP status code (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        Task<IHttpResponse<TResponse>> RequestAsync<TResponse>(Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken) where TResponse : object;
    }
}
