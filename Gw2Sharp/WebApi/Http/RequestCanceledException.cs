namespace Gw2Sharp.WebApi.Http
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
        public RequestCanceledException(IHttpRequest request) : base(request, "Request was canceled") { }
    }
}
