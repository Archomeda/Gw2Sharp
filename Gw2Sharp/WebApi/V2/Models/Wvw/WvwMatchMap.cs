using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW match map.
    /// </summary>
    public class WvwMatchMap : ApiV2BaseObject
    {
        /// <summary>
        /// The map id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The map type.
        /// </summary>
        public ApiEnum<WvwMapType> Type { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// The map score distribution per team.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The map bonuses.
        /// </summary>
        public IReadOnlyList<WvwMatchMapBonus> Bonuses { get; set; } = Array.Empty<WvwMatchMapBonus>();

        /// <summary>
        /// The map objectives.
        /// </summary>
        public IReadOnlyList<WvwMatchMapObjective> Objectives { get; set; } = Array.Empty<WvwMatchMapObjective>();

        /// <summary>
        /// The map kill distribution per team.
        /// </summary>
        public WvwMatchTeamValues Kills { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The map death distribution per team.
        /// </summary>
        public WvwMatchTeamValues Deaths { get; set; } = new WvwMatchTeamValues();
    }
}
