using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a streaming web API response.
    /// </summary>
    public interface IHttpResponseStream
    {
        /// <summary>
        /// The content stream.
        /// </summary>
        Stream ContentStream { get; }

        /// <summary>
        /// The status code.
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The original headers that were used in the web request.
        /// </summary>
        IReadOnlyDictionary<string, string> RequestHeaders { get; }

        /// <summary>
        /// The response headers.
        /// </summary>
        IReadOnlyDictionary<string, string> ResponseHeaders { get; }
    }
}
