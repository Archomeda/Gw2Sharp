using System;
using System.Collections.Generic;
using System.Threading;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;

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
        /// The API base URL that is used to construct the final URL for the API requests.
        /// </summary>
        string ApiBaseUrl { get; }

        /// <summary>
        /// The render base URL that is used to replace the render API hostname that are returned from the API.
        /// If <see langword="null"/>, the hostname is not replaced.
        /// </summary>
        string? RenderBaseUrl { get; }

        /// <summary>
        /// Gets the request timeout that's used for the API requests.
        /// If <see cref="TimeSpan.Zero"/> or less, the default timeout is used.
        /// This value can be <see cref="Timeout.InfiniteTimeSpan"/> to have no timeout.
        /// Defaults to the same value as <see cref="IHttpClient.Timeout"/> in <see cref="HttpClient"/>.
        /// </summary>
        TimeSpan RequestTimeout { get; }

        /// <summary>
        /// Gets the HTTP client that's used for the API requests.
        /// </summary>
        /// <exception cref="ArgumentNullException"><c>value</c> is <see langword="null"/>.</exception>
        IHttpClient HttpClient { get; }

        /// <summary>
        /// Gets the cache controller that's used for API requests.
        /// </summary>
        /// <exception cref="ArgumentNullException"><c>value</c> is <see langword="null"/>.</exception>
        ICacheMethod CacheMethod { get; }

        /// <summary>
        /// Gets the render cache duration.
        /// If set to <see cref="TimeSpan.Zero"/>, the cache time that the render server returns in the headers will be used.
        /// </summary>
        TimeSpan RenderCacheDuration { get; }

        /// <summary>
        /// Gets the cache controller that's used for render file API requests.
        /// </summary>
        /// <exception cref="ArgumentNullException"><c>value</c> is <see langword="null"/>.</exception>
        ICacheMethod RenderCacheMethod { get; }

        /// <summary>
        /// Gets the list of middleware that will be used for web API requests.
        /// The list determines the order of middleware execution.
        /// </summary>
        IList<IWebApiMiddleware> Middleware { get; }

        /// <summary>
        /// Gets the hash code of the list of middleware.
        /// This value can be used to determine if the list has changed.
        /// </summary>
        int MiddlewareHashCode { get; }
    }
}
