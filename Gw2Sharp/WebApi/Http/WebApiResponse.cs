using System;
using System.Collections.Generic;
using System.Net;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A generic JSON web response.
    /// </summary>
    public class WebApiResponse : WebApiResponse<string>, IWebApiResponse
    {
        /// <summary>
        /// Creates a new <see cref="WebApiResponse" /> with a string as backing content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(string content) : base(content, null, null) { }

        /// <summary>
        /// Creates a new <see cref="WebApiResponse" /> with a string as backing content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(string content, HttpStatusCode? statusCode, IDictionary<string, string>? responseHeaders)
            : base(content, statusCode, responseHeaders) { }

        /// <summary>
        /// Creates a new <see cref="WebApiResponse" /> with a string as backing content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(string content, HttpStatusCode? statusCode, IEnumerable<KeyValuePair<string, string>>? responseHeaders)
            : base(content, statusCode, responseHeaders) { }

        /// <inheritdoc />
        public new IWebApiResponse Copy() =>
            new WebApiResponse(this.Content, this.StatusCode, this.ResponseHeaders);
    }

    /// <summary>
    /// A deserialized web response.
    /// </summary>
    /// <typeparam name="T">The response object type.</typeparam>
    public class WebApiResponse<T> : IWebApiResponse<T>
    {
        /// <summary>
        /// Creates a new <see cref="WebApiResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(T content) : this(content, null, null) { }

        /// <summary>
        /// Creates a new <see cref="WebApiResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(T content, HttpStatusCode? statusCode, IDictionary<string, string>? responseHeaders)
        {
            this.Content = content ?? throw new ArgumentNullException(nameof(content));
            if (statusCode != null)
                this.StatusCode = statusCode.Value;
            if (responseHeaders != null)
                this.ResponseHeaders = responseHeaders.ShallowCopy();
        }

        /// <summary>
        /// Creates a new <see cref="WebApiResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public WebApiResponse(T content, HttpStatusCode? statusCode, IEnumerable<KeyValuePair<string, string>>? responseHeaders) :
            this(content, statusCode, responseHeaders?.ShallowCopy()) { }

        /// <inheritdoc />
        public T Content { get; set; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode { get; set; } = 0;

        /// <inheritdoc />
        public IDictionary<string, string> ResponseHeaders { get; } = new Dictionary<string, string>();

        /// <inheritdoc />
        public IWebApiResponse<T> Copy() =>
            new WebApiResponse<T>(this.Content, this.StatusCode, this.ResponseHeaders);
    }
}
