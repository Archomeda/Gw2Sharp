using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a generic JSON web API response.
    /// </summary>
    public interface IHttpResponse : IHttpResponse<string> { }

    /// <summary>
    /// An interface for implementing a deserialized web API response.
    /// </summary>
    public interface IHttpResponse<T> : ISerializable
    {
        /// <summary>
        /// The content.
        /// </summary>
        T Content { get; }

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
