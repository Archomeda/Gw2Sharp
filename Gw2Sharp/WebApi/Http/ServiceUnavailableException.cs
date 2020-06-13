using System;
using System.Runtime.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails due to the service being unavailable (code 500).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    [Serializable]
    public class ServiceUnavailableException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="ServiceUnavailableException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public ServiceUnavailableException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, response?.Content.Message ?? string.Empty)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="ServiceUnavailableException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
