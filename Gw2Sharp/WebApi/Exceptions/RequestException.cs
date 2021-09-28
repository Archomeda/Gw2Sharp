using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    public class RequestException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, string message) :
            this(request, null, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, IWebApiResponse<ErrorObject>? response, string message) :
            this(request, response, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, string message, Exception? innerException) :
            this(request, null, message, innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IWebApiRequest request, IWebApiResponse<ErrorObject>? response, string message, Exception? innerException) :
            base(message, innerException)
        {
            this.Request = request ?? throw new ArgumentNullException(nameof(request));
            this.Response = response;
        }

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IWebApiRequest Request { get; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public IWebApiResponse<ErrorObject>? Response { get; }
    }
}
