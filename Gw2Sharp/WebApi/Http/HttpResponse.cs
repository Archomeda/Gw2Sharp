using System.Collections.Generic;
using System.Net;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A generic JSON web response.
    /// </summary>
    public class HttpResponse : HttpResponse<string>, IHttpResponse { }

    /// <summary>
    /// A deserialized web response.
    /// </summary>
    public class HttpResponse<T> : IHttpResponse<T>
    {
        /// <inheritdoc />
        public T Content { get; set; }

        /// <inheritdoc />
        public HttpStatusCode StatusCode { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> ResponseHeaders { get; set; }
    }
}
