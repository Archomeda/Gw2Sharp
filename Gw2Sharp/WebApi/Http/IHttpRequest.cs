using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An interface for implementing a web API request.
    /// </summary>
    public interface IHttpRequest : ISerializable
    {
        /// <summary>
        /// The URL.
        /// </summary>
        Uri Url { get; set; }

        /// <summary>
        /// The request headers to use in the web request.
        /// </summary>
        IReadOnlyDictionary<string, string> RequestHeaders { get; }
    }
}
