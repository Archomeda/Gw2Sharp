using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the scores of a WvW match.
    /// </summary>
    public class WvwMatchScores : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The match id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The team scores.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The number of gained victory points per team.
        /// </summary>
        public WvwMatchTeamValues VictoryPoints { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The match scores per map.
        /// </summary>
        public IReadOnlyList<WvwMatchScoresMap> Maps { get; set; } = Array.Empty<WvwMatchScoresMap>();

        /// <summary>
        /// The match skirmishes.
        /// </summary>
        public IReadOnlyList<WvwMatchSkirmish> Skirmishes { get; set; } = Array.Empty<WvwMatchSkirmish>();
    }
}
