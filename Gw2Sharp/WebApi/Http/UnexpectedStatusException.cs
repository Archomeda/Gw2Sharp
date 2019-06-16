using System;
using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An exception that's used when an HTTP request returned an unexpected status code, e.g. a non-successful one.
    /// </summary>
    [Serializable]
    public class UnexpectedStatusException : RequestException
    {
        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IHttpRequest request, IHttpResponse<string> response) :
            this(request, response, $"Unexpected HTTP status code: {(int?)response?.StatusCode ?? 0}")
        { }

        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IHttpRequest request, IHttpResponse<string>? response, string message) :
            base(request, response, message)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="UnexpectedStatusException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected UnexpectedStatusException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// An exception that's used when an HTTP request returned an unexpected status code, e.g. a non-successful one.
    /// </summary>
    [Serializable]
    public class UnexpectedStatusException<T> : RequestException<T>
    {
        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException{T}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IHttpRequest request, IHttpResponse<T> response) :
            this(request, response, $"Unexpected HTTP status code: {(int?)response?.StatusCode ?? 0}")
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
        }

        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException{T}" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IHttpRequest request, IHttpResponse<T>? response, string message) :
            base(request, response, message)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="UnexpectedStatusException{T}"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected UnexpectedStatusException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
