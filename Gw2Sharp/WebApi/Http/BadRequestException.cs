using System;
using System.Runtime.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a bad request was done (code 400).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    [Serializable]
    public class BadRequestException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public BadRequestException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, response?.Content.Message ?? string.Empty)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
