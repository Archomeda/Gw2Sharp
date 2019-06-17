using System;
using System.Runtime.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    [Serializable]
    public class AuthorizationRequiredException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="AuthorizationRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/>, <paramref name="response"/> or <paramref name="error"/> is <c>null</c>.</exception>
        public AuthorizationRequiredException(IHttpRequest request, IHttpResponse<ErrorObject> response, AuthorizationError error) :
            base(request, response, response.Content.Message)
        {
            this.AuthorizationError = error;
        }

        /// <summary>
        /// Deserialization constructor for <see cref="AuthorizationRequiredException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected AuthorizationRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.AuthorizationError = (AuthorizationError)info.GetValue(nameof(this.AuthorizationError), typeof(AuthorizationError));
        }

        /// <summary>
        /// The reason why authorization has failed.
        /// </summary>
        public AuthorizationError AuthorizationError { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(this.AuthorizationError), this.AuthorizationError, typeof(AuthorizationError));

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Creates a specific Exception derived from <see cref="AuthorizationRequiredException"/> from a response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The exception.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public static AuthorizationRequiredException CreateFromResponse(IHttpRequest request, IHttpResponse<ErrorObject> response)
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
