using System.Text.RegularExpressions;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class AuthorizationRequiredException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="AuthorizationRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        public AuthorizationRequiredException(IHttpRequest request, IHttpResponse<ErrorObject> response, AuthorizationError error) :
            base(request, response, response.Content.Message)
        {
            this.AuthorizationError = error;
        }

        /// <summary>
        /// The reason why authorization has failed.
        /// </summary>
        public AuthorizationError AuthorizationError { get; }

        /// <summary>
        /// Creates a specific Exception derived from <see cref="AuthorizationRequiredException"/> from a response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The exception.</returns>
        public static AuthorizationRequiredException CreateFromResponse(IHttpRequest request, IHttpResponse<ErrorObject> response)
        {
            switch (response.Content.Message)
            {
                case "invalid key":
                    return new InvalidAccessTokenException(request, response);
                case var message when message.StartsWith("requires scope") || message.StartsWith("requires at least one scope from"):
                    return new MissingScopesException(request, response);
                case "membership required":
                    return new MembershipRequiredException(request, response);
                case "access restricted to guild leaders":
                    return new RestrictedToGuildLeadersException(request, response);
                case "endpoint requires authentication":
                default:
                    return new AuthorizationRequiredException(request, response, AuthorizationError.RequiresAuthorization);
            }
        }
    }
}
