using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A generic JSON web response.
    /// </summary>
    [Serializable]
    public class HttpResponse : HttpResponse<string>, IHttpResponse
    {
        /// <inheritdoc />
        public HttpResponse(string content) : base(content, null, null, null) { }

        /// <inheritdoc />
        public HttpResponse(string content, HttpStatusCode? statusCode, IDictionary<string, string>? requestHeaders, IDictionary<string, string>? responseHeaders)
            : base(content, statusCode, requestHeaders, responseHeaders) { }

        /// <summary>
        /// Deserialization constructor for <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected HttpResponse(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// A deserialized web response.
    /// </summary>
    [Serializable]
    public class HttpResponse<T> : IHttpResponse<T>
    {
        /// <summary>
        /// Creates a new <see cref="HttpResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public HttpResponse(T content) : this(content, null, null, null) { }

        /// <summary>
        /// Creates a new <see cref="HttpResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public HttpResponse(T content, HttpStatusCode? statusCode, IDictionary<string, string>? requestHeaders, IDictionary<string, string>? responseHeaders)
        {
            this.Content = content ?? throw new ArgumentNullException(nameof(content));
            if (statusCode != null)
                this.StatusCode = statusCode.Value;
            if (requestHeaders != null)
                this.RequestHeaders = requestHeaders.ShallowCopy().AsReadOnly();
            if (responseHeaders != null)
                this.ResponseHeaders = responseHeaders.ShallowCopy().AsReadOnly();
        }

        /// <summary>
        /// Creates a new <see cref="HttpResponse{T}" />.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="requestHeaders">The original headers that were used in the web request.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is <c>null</c>.</exception>
        public HttpResponse(T content, HttpStatusCode? statusCode, IEnumerable<KeyValuePair<string, string>>? requestHeaders, IEnumerable<KeyValuePair<string, string>>? responseHeaders) :
            this(content, statusCode, requestHeaders?.ShallowCopy(), responseHeaders?.ShallowCopy())
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="HttpResponse{T}"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected HttpResponse(SerializationInfo info, StreamingContext context)
        {
            this.Content = (T)info.GetValue(nameof(this.Content), typeof(T));
            this.StatusCode = (HttpStatusCode)info.GetValue(nameof(this.StatusCode), typeof(HttpStatusCode));
            this.RequestHeaders = (IReadOnlyDictionary<string, string>)info.GetValue(nameof(this.RequestHeaders), typeof(IReadOnlyDictionary<string, string>));
            this.ResponseHeaders = (IReadOnlyDictionary<string, string>)info.GetValue(nameof(this.ResponseHeaders), typeof(IReadOnlyDictionary<string, string>));
        }

        /// <inheritdoc />
        public T Content { get; set; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode { get; set; } = 0;

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; } = new Dictionary<string, string>().AsReadOnly();

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> ResponseHeaders { get; } = new Dictionary<string, string>().AsReadOnly();

        /// <inheritdoc />
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(this.Content), this.Content, typeof(T));
            info.AddValue(nameof(this.StatusCode), this.StatusCode, typeof(HttpStatusCode));
            info.AddValue(nameof(this.RequestHeaders), this.RequestHeaders, typeof(IReadOnlyDictionary<string, string>));
            info.AddValue(nameof(this.ResponseHeaders), this.ResponseHeaders, typeof(IReadOnlyDictionary<string, string>));
        }
    }
}
