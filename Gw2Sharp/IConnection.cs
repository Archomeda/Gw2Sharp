using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp
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
        /// <exception cref="ArgumentNullException"><c>value</c> is <c>null</c>.</exception>
        IHttpClient HttpClient { get; }

        /// <summary>
        /// Gets the cache controller that's used for API requests.
        /// </summary>
        /// <exception cref="ArgumentNullException"><c>value</c> is <c>null</c>.</exception>
        ICacheMethod CacheMethod { get; }

        /// <summary>
        /// Gets the render cache duration.
        /// If set to <see cref="TimeSpan.Zero"/>, the cache time that the render server returns in the headers will be used.
        /// </summary>
        TimeSpan RenderCacheDuration { get; }

        /// <summary>
        /// Gets the cache controller that's used for render file API requests.
        /// </summary>
        /// <exception cref="ArgumentNullException"><c>value</c> is <c>null</c>.</exception>
        ICacheMethod RenderCacheMethod { get; }

        /// <summary>
        /// Requests data from the API.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="client">The Guild Wars 2 Web API client.</param>
        /// <param name="requestUri">The request Uri.</param>
        /// <param name="additionalHeaders">Additional request headers.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response with the object as the requested response type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="requestUri"/> is <c>null</c>.</exception>
        /// <exception cref="RequestException">A generic request error occurs (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="RequestCanceledException">The request is canceled by the user or because of a timeout (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        /// <exception cref="UnexpectedStatusException">The server returns a non-successful HTTP status code (<seealso cref="IHttpClient.RequestAsync"/>).</exception>
        Task<IHttpResponse<TResponse>> RequestAsync<TResponse>(IGw2Client client, Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken);
    }
}
