using System;
using System.Collections.Generic;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web request.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        /// <summary>
        /// Creates a new <see cref="HttpRequest" />.
        /// </summary>
        public HttpRequest() { }

        /// <summary>
        /// Creates a new <see cref="HttpRequest" />.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="requestHeaders">The request headers to use in the web request.</param>
        public HttpRequest(Uri? url, IDictionary<string, string>? requestHeaders)
        {
            this.Url = url;
            if (this.RequestHeaders != null)
                this.RequestHeaders = new Dictionary<string, string>(requestHeaders).AsReadOnly();
        }

        /// <summary>
        /// Creates a new <see cref="HttpRequest" />.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="requestHeaders">The request headers to use in the web request.</param>
        public HttpRequest(Uri? url, IEnumerable<KeyValuePair<string, string>>? requestHeaders) :
            this(url, requestHeaders?.ShallowCopy()) { }

        /// <inheritdoc />
        public Uri? Url { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>().AsReadOnly();
    }
}
