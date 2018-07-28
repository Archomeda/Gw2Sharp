using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// Provides extensions related to HTTP clients.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Adds a range of headers to a <see cref="HttpHeaders" /> object.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <param name="headers">The headers to add.</param>
        public static void AddRange(this HttpHeaders target, IEnumerable<KeyValuePair<string, string>> headers)
        {
            foreach (var header in headers)
                target.Add(header.Key, header.Value);
        }
    }
}
