using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web request.
    /// </summary>
    [Serializable]
    public class HttpRequest : IHttpRequest
    {
        /// <summary>
        /// Creates a new <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        public HttpRequest(Uri url) : this(url, null) { }

        /// <summary>
        /// Creates a new <see cref="HttpRequest" />.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="requestHeaders">The request headers to use in the web request.</param>
        public HttpRequest(Uri url, IDictionary<string, string>? requestHeaders)
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
        public HttpRequest(Uri url, IEnumerable<KeyValuePair<string, string>> requestHeaders) :
            this(url, requestHeaders?.ShallowCopy())
        { }

        /// <summary>
        /// Deserialization constructor for <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected HttpRequest(SerializationInfo info, StreamingContext context)
        {
            this.Url = (Uri)info.GetValue(nameof(this.Url), typeof(Uri));
            this.RequestHeaders = (IReadOnlyDictionary<string, string>)info.GetValue(nameof(this.RequestHeaders), typeof(IReadOnlyDictionary<string, string>));
        }

        /// <inheritdoc />
        public Uri Url { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>().AsReadOnly();

        /// <inheritdoc />
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(this.Url), this.Url, typeof(Uri));
            info.AddValue(nameof(this.RequestHeaders), this.RequestHeaders, typeof(IReadOnlyDictionary<string, string>));
        }
    }
}
