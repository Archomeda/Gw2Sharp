using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a request fails due to issuing too many requests in a short period of time (code 429).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException" />
    public class TooManyRequestsException : UnexpectedStatusException
    {
        /// <summary>
        /// Creates a new <see cref="TooManyRequestsException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <see langword="null"/>.</exception>
        public TooManyRequestsException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response)
        { }
    }
}
