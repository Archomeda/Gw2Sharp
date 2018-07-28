using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails due to an internal server error (code 500).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class ServerErrorException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="ServerErrorException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public ServerErrorException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, response.Content.Message) { }
    }
}
