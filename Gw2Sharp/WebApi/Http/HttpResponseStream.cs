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
        /// <param name="cacheState">The cache state.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <see langword="null"/>.</exception>
        public HttpResponseStream(Stream contentStream, CacheState cacheState) : this(contentStream, null, cacheState, null, null) { }

        /// <summary>
        /// Creates a new <see cref="HttpResponseStream" />.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="cacheState">The cache state.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <see langword="null"/>.</exception>
        public HttpResponseStream(Stream contentStream, HttpStatusCode? statusCode, CacheState cacheState,
            IDictionary<string, string>? requestHeaders, IDictionary<string, string>? responseHeaders)
        {
            this.ContentStream = contentStream ?? throw new ArgumentNullException(nameof(contentStream));
            if (statusCode.HasValue)
                this.StatusCode = statusCode.Value;
            this.CacheState = cacheState;
            if (requestHeaders != null)
                this.RequestHeaders = requestHeaders.ShallowCopy().AsReadOnly();
            if (!(responseHeaders is null))
                this.ResponseHeaders = responseHeaders.ShallowCopy().AsReadOnly();
        }

        /// <summary>
        /// Creates a new <see cref="HttpResponseStream" />.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="cacheState">The cache state.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentStream"/> is <see langword="null"/>.</exception>
        public HttpResponseStream(Stream contentStream, HttpStatusCode? statusCode, CacheState cacheState,
            IEnumerable<KeyValuePair<string, string>>? requestHeaders, IEnumerable<KeyValuePair<string, string>>? responseHeaders) :
            this(contentStream, statusCode, cacheState, requestHeaders?.ShallowCopy(), responseHeaders?.ShallowCopy())
        { }

        /// <inheritdoc />
        public Stream ContentStream { get; set; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode { get; set; } = 0;

        /// <inheritdoc />
        public CacheState CacheState { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; } = new Dictionary<string, string>().AsReadOnly();

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> ResponseHeaders { get; } = new Dictionary<string, string>().AsReadOnly();


        private bool isDisposed = false; // To detect redundant calls

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="isDisposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                    this.ContentStream?.Dispose();
                this.isDisposed = true;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
