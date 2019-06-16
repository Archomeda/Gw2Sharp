using System;
using System.Runtime.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a response cannot be found (code 404).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    [Serializable]
    public class NotFoundException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="NotFoundException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public NotFoundException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, response.Content.Message)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
