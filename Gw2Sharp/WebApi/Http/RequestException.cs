using System;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    public class RequestException : RequestException<string>
    {
        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        public RequestException(IHttpRequest request) : base(request) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public RequestException(IHttpRequest request, IHttpResponse<string> response) :
            base(request, response) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        public RequestException(IHttpRequest request, string message) :
            base(request, message) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        public RequestException(IHttpRequest request, IHttpResponse<string> response, string message) :
            base(request, response, message) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IHttpRequest request, string message, Exception innerException) :
            base(request, message, innerException) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IHttpRequest request, IHttpResponse<string> response, string message, Exception innerException) :
            base(request, response, message, innerException) { }
    }


    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    /// <typeparam name="TResponse">The response object.</typeparam>
    public class RequestException<TResponse> : Exception
    {
        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        public RequestException(IHttpRequest request) : this(request, null, null, null) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public RequestException(IHttpRequest request, IHttpResponse<TResponse> response) :
            this(request, response, null, null) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        public RequestException(IHttpRequest request, string message) :
            this(request, null, message, null) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        public RequestException(IHttpRequest request, IHttpResponse<TResponse> response, string message) :
            this(request, response, message, null) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IHttpRequest request, string message, Exception innerException) :
            this(request, null, message, innerException) { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IHttpRequest request, IHttpResponse<TResponse> response, string message, Exception innerException) :
            base(message, innerException)
        {
            this.Request = request;
            this.Response = response;
        }

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IHttpRequest Request { get; }

        /// <summary>
        /// Gets the response; can be <c>null</c>.
        /// </summary>
        public IHttpResponse<TResponse> Response { get; }
    }
}
