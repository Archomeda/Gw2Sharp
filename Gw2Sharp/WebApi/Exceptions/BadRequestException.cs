using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// A web API specific exception that's used when a bad request was done (code 400).
    /// </summary>
    /// <seealso cref="UnexpectedStatusException" />
    public class BadRequestException : UnexpectedStatusException
    {
        /// <summary>
        /// Creates a new <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public BadRequestException(IWebApiRequest request, IWebApiResponse<ErrorObject> response, BadRequestError error) :
            base(request, response)
        {
            this.BadRequestError = error;
        }

        /// <summary>
        /// The reason why authorization has failed.
        /// </summary>
        public BadRequestError BadRequestError { get; }

        /// <summary>
        /// Creates a specific exception derived from <see cref="BadRequestException"/> from a response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The exception.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public static BadRequestException CreateFromResponse(IWebApiRequest request, IWebApiResponse<ErrorObject> response)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            switch (response.Content.Message.ToLowerInvariant())
            {
                case var message when message.StartsWith("id list too long; this endpoint is limited to", StringComparison.InvariantCultureIgnoreCase):
                    return new ListTooLongException(request, response);
                case var message when message.StartsWith("page out of range. Use page values", StringComparison.InvariantCultureIgnoreCase):
                    return new PageOutOfRangeException(request, response);
                default:
                    return new BadRequestException(request, response, BadRequestError.GenericBadRequest);
            }
        }
    }
}
