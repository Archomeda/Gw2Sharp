using System;
using System.Runtime.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web API specific exception that's used when a request fails to authorize due to the owner of the API key not being a member of the guild (code 403).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    [Serializable]
    public class MembershipRequiredException : AuthorizationRequiredException
    {
        /// <summary>
        /// Creates a new <see cref="MembershipRequiredException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public MembershipRequiredException(IHttpRequest request, IHttpResponse<ErrorObject> response) :
            base(request, response, AuthorizationError.MembershipRequired)
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="MembershipRequiredException"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected MembershipRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
