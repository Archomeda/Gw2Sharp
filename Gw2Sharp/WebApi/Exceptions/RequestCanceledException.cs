using System;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Exceptions
{
    /// <summary>
    /// An exception that's used when an HTTP request has been canceled.
    /// </summary>
    public class RequestCanceledException : RequestException
    {
        /// <summary>
        /// Creates a new <see cref="RequestCanceledException" />.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is <see langword="null"/>.</exception>
        public RequestCanceledException(IWebApiRequest request) :
            base(request, "Request was canceled") { }
    }
}
