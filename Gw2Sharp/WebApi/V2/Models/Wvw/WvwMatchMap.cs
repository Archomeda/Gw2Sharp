using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match map.
    /// </summary>
    public class WvwMatchMap : ApiV2BaseObject
    {
        /// <summary>
        /// The map id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The map type
        /// </summary>
        public ApiEnum<WvwMapType> Type { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// The map's score distribution by color
        /// </summary>
        public WvwMatchWorldValueContainer? Scores { get; set; }

        /// <summary>
        /// The map's bonuses
        /// </summary>
        public IReadOnlyList<WvwMatchMapBonus> Bonuses { get; set; } = Array.Empty<WvwMatchMapBonus>();

        /// <summary>
        /// the map's objectives
        /// </summary>
        public IReadOnlyList<WvwMatchMapObjective> Objectives { get; set; } = Array.Empty<WvwMatchMapObjective>();

        /// <summary>
        /// The map's kill distribution by color
        /// </summary>
        public WvwMatchWorldValueContainer? Kills { get; set; }

        /// <summary>
        /// The map's death distribution by color
        /// </summary>
        public WvwMatchWorldValueContainer? Deaths { get; set; }

    }
}
