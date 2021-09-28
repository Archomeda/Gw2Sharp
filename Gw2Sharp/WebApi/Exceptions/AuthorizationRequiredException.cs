using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException" />
    public class AuthorizationRequiredException : UnexpectedStatusException
    {
        /// <summary>
        /// Creates a new <see cref="AuthorizationRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/>, <paramref name="response"/> or <paramref name="error"/> is <see langword="null"/>.</exception>
        public AuthorizationRequiredException(IWebApiRequest request, IWebApiResponse<ErrorObject> response, AuthorizationError error) :
            base(request, response)
        {
            this.AuthorizationError = error;
        }

        /// <summary>
        /// The reason why authorization has failed.
        /// </summary>
        public AuthorizationError AuthorizationError { get; }

        /// <summary>
        /// Creates a specific exception derived from <see cref="AuthorizationRequiredException"/> from a response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The exception.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <see langword="null"/>.</exception>
        public static AuthorizationRequiredException CreateFromResponse(IWebApiRequest request, IWebApiResponse<ErrorObject> response)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            switch (response.Content.Message.ToLowerInvariant())
            {
                case "invalid key":
                case "invalid access token":
                    return new InvalidAccessTokenException(request, response);
                case var message when message.StartsWith("requires scope", StringComparison.InvariantCultureIgnoreCase) || message.StartsWith("requires at least one scope from", StringComparison.InvariantCultureIgnoreCase):
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
