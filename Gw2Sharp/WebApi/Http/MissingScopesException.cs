using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize due to missing permissions (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class MissingScopesException : AuthorizationRequiredException
    {
        /// <summary>
        /// Creates a new <see cref="MissingScopesException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        public MissingScopesException(IHttpRequest request, IHttpResponse<ErrorObject> response) : base(request, response, AuthorizationError.MissingScopes) { }
    }
}
