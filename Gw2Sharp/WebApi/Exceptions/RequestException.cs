using System;
using Gw2Sharp.WebApi.Http;

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
        public RequestException(IWebApiRequest request, IWebApiResponse<string>? response, string message) :
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
        public RequestException(IWebApiRequest request, IWebApiResponse<string>? response, string message, Exception? innerException) :
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
        public IWebApiResponse<string>? Response { get; }
    }


    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    /// <typeparam name="TResponse">The response object.</typeparam>
    public class RequestException<TResponse> : RequestException
    {
        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, string message) :
            this(request, null, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, IWebApiResponse<TResponse>? response, string message) :
            this(request, response, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <see langword="null"/>.</exception>
        public RequestException(IWebApiRequest request, string message, Exception? innerException) :
            this(request, null, message, innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IWebApiRequest request, IWebApiResponse<TResponse>? response, string message, Exception? innerException) :
            base(request, null, message, innerException)
        {
            this.Response = response;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public new IWebApiResponse<TResponse>? Response { get; }
    }
}
