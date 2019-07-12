using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A streaming web response.
    /// </summary>
    public class HttpResponseStream : IHttpResponseStream
    {
        /// <summary>
        /// Creates a new <see cref="HttpResponseStream" />.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <c>null</c>.</exception>
        public HttpResponseStream(Stream contentStream) : this(contentStream, null, null, null) { }

        /// <summary>
        /// Creates a new <see cref="HttpResponseStream" />.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <c>null</c>.</exception>
        public HttpResponseStream(Stream contentStream, HttpStatusCode? statusCode, IDictionary<string, string>? requestHeaders, IDictionary<string, string>? responseHeaders)
        {
            this.ContentStream = contentStream ?? throw new ArgumentNullException(nameof(contentStream));
            if (statusCode != null)
                this.StatusCode = statusCode.Value;
            if (requestHeaders != null)
                this.RequestHeaders = requestHeaders.ShallowCopy().AsReadOnly();
            if (responseHeaders != null)
                this.ResponseHeaders = responseHeaders.ShallowCopy().AsReadOnly();
        }

        /// <summary>
        /// Creates a new <see cref="HttpResponseStream" />.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <c>null</c>.</exception>
        public HttpResponseStream(Stream contentStream, HttpStatusCode? statusCode, IEnumerable<KeyValuePair<string, string>>? requestHeaders, IEnumerable<KeyValuePair<string, string>>? responseHeaders) :
            this(contentStream, statusCode, requestHeaders?.ShallowCopy(), responseHeaders?.ShallowCopy())
        { }

        /// <inheritdoc />
        public Stream ContentStream { get; set; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode { get; set; } = 0;

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; } = new Dictionary<string, string>().AsReadOnly();

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> ResponseHeaders { get; } = new Dictionary<string, string>().AsReadOnly();
    }
}
