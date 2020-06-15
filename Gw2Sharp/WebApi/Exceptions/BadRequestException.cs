using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a bad request was done (code 400).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException{Error}" />
    public class BadRequestException : UnexpectedStatusException<ErrorObject>
    {
        /// <summary>
        /// Creates a new <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public BadRequestException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            base(request, response, response?.Content.Message ?? string.Empty) { }
    }
}
