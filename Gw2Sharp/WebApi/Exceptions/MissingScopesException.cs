using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
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
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public MissingScopesException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response, AuthorizationError.MissingScopes) { }
    }
}
