using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a response cannot be found (code 404).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
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
    }
}
