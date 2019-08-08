using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a raid wing.
    /// </summary>
    public class RaidWing
    {
        /// <summary>
        /// The raid wing id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The raid wing events.
        /// </summary>
        public IReadOnlyList<RaidWingEvent> Events { get; set; } = new List<RaidWingEvent>();
    }
}
