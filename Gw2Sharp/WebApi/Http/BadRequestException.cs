using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a bad request was done (code 400).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class BadRequestException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public BadRequestException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, response.Content.Message) { }
    }
}
