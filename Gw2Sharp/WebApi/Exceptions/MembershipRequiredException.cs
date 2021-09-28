using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize due to the owner of the API key not being a member of the guild (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class MembershipRequiredException : AuthorizationRequiredException
    {
        /// <summary>
        /// Creates a new <see cref="MembershipRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <see langword="null"/>.</exception>
        public MembershipRequiredException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response, AuthorizationError.MembershipRequired) { }
    }
}
