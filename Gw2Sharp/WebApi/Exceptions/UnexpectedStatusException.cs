using System;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// An exception that's used when an HTTP request returned an unexpected status code, e.g. a non-successful one.
    /// </summary>
    public class UnexpectedStatusException : RequestException
    {
        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<string> response) :
            this(request, response, $"Unexpected HTTP status code: {(int?)response?.StatusCode ?? 0}") { }

        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<string>? response, string message) :
            base(request, response, message) { }
    }

    /// <summary>
    /// An exception that's used when an HTTP request returned an unexpected status code, e.g. a non-successful one.
    /// </summary>
    public class UnexpectedStatusException<T> : RequestException<T>
    {
        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException{T}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<T> response) :
            this(request, response, $"Unexpected HTTP status code: {(int?)response?.StatusCode ?? 0}") { }

        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException{T}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<T>? response, string message) :
            base(request, response, message) { }
    }
}
