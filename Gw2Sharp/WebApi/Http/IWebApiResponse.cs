using System.Collections.Generic;
using System.Net;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a generic JSON web API response.
    /// </summary>
    public interface IWebApiResponse : IWebApiResponse<string> { }

    /// <summary>
    /// An interface for implementing a deserialized web API response.
    /// </summary>
    /// <typeparam name="T">The response object type.</typeparam>
    public interface IWebApiResponse<out T>
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
        /// The response headers.
        /// </summary>
        IReadOnlyDictionary<string, string> ResponseHeaders { get; }
    }
}
