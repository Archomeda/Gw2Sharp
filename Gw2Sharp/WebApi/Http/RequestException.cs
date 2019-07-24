using System;
using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    [Serializable]
    public class RequestException : RequestException<string>
    {
        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, string message) :
            base(request, message)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, IHttpResponse<string>? response, string message) :
            base(request, response, message)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, string message, Exception? innerException) :
            base(request, message, innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, IHttpResponse<string>? response, string message, Exception innerException) :
            base(request, response, message, innerException)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="RequestException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected RequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }


    /// <summary>
    /// A generic request exception used for the web API.
    /// </summary>
    /// <typeparam name="TResponse">The response object.</typeparam>
    [Serializable]
    public class RequestException<TResponse> : Exception
    {
        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, string message) :
            this(request, null, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, IHttpResponse<TResponse>? response, string message) :
            this(request, response, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public RequestException(IHttpRequest request, string message, Exception? innerException) :
            this(request, null, message, innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RequestException{TResponse}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestException(IHttpRequest request, IHttpResponse<TResponse>? response, string message, Exception? innerException) :
            base(message, innerException)
        {
            this.Request = request ?? throw new ArgumentNullException(nameof(request));
            this.Response = response;
        }

        /// <summary>
        /// Deserialization constructor for <see cref="RequestException{TResponse}"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected RequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Request = (IHttpRequest)info.GetValue(nameof(this.Request), typeof(IHttpRequest));
            this.Response = (IHttpResponse<TResponse>?)info.GetValue(nameof(this.Response), typeof(IHttpResponse<TResponse>));
        }

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IHttpRequest Request { get; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        public IHttpResponse<TResponse>? Response { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(this.Request), this.Request, typeof(IHttpRequest));
            info.AddValue(nameof(this.Response), this.Response, typeof(IHttpResponse<TResponse>));

            base.GetObjectData(info, context);
        }
    }
}
