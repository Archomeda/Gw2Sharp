using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize due to the owner not being a guild leader (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class RestrictedToGuildLeadersException : AuthorizationRequiredException
    {
        /// <summary>
        /// Creates a new <see cref="RestrictedToGuildLeadersException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public RestrictedToGuildLeadersException(IHttpRequest request, IHttpResponse<ErrorObject> response) : base(request, response, AuthorizationError.AccessRestrictedToGuildLeaders) { }
    }
}
