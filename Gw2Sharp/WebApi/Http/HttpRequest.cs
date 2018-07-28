using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web request.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        /// <inheritdoc />
        public Uri Url { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; }
    }
}
