using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a raid.
    /// </summary>
    public class Raid : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The raid id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The raid wings.
        /// </summary>
        public IReadOnlyList<RaidWing> Wings { get; set; } = Array.Empty<RaidWing>();
    }
}
