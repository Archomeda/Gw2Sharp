using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a request fails due to the service being unavailable (code 500).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class ServiceUnavailableException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="ServiceUnavailableException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <see langword="null"/>.</exception>
        public ServiceUnavailableException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response, response?.Content.Message ?? string.Empty) { }
    }
}
