using System;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// An exception that's used when an HTTP request returned an unexpected status code, e.g. a non-successful one.
    /// </summary>
    public class UnexpectedStatusException : RequestException
    {
        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="response"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<ErrorObject> response) :
            this(request, response, FormatMessage(response))
        { }

        /// <summary>
        /// Creates a new <see cref="UnexpectedStatusException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> or <paramref name="message"/> is <c>null</c>.</exception>
        public UnexpectedStatusException(IWebApiRequest request, IWebApiResponse<ErrorObject>? response, string message) :
            base(request, response, message)
        { }


        private static string FormatMessage(IWebApiResponse<ErrorObject> response)
        {
            if (response is null)
                return "Unexpected response (no additional information available)";

            if (!string.IsNullOrEmpty(response.Content?.Message))
                return response.Content.Message;

            return $"Unexpected HTTP status code: {(int)response.StatusCode}";
        }
    }
}
