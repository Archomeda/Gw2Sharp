using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the stats of a WvW match.
    /// </summary>
    public class WvwMatchStats : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The match id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The number of kills per team.
        /// </summary>
        public WvwMatchTeamValues Kills { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The number of deaths per team.
        /// </summary>
        public WvwMatchTeamValues Deaths { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The match map states.
        /// </summary>
        public IReadOnlyList<WvwMatchStatsMap> Maps { get; set; } = Array.Empty<WvwMatchStatsMap>();
    }
}
