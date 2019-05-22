using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a subtoken info.
    /// </summary>
    public class SubTokenInfo : TokenInfo
    {
        /// <summary>
        /// The subtoken's expiry date.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// The subtoken's creation date.
        /// </summary>
        public DateTime IssuedAt { get; set; }

        /// <summary>
        /// The list of URLs that this subtoken has access to.
        /// </summary>
        public IReadOnlyList<string> Urls { get; set; } = new List<string>();
    }
}
