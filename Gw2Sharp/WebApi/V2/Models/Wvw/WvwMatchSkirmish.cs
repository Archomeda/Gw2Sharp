using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW match skirmish.
    /// </summary>
    public class WvwMatchSkirmish : ApiV2BaseObject
    {
        /// <summary>
        /// The ability id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Skirmish scores per team.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// Map scores.
        /// </summary>
        public IReadOnlyList<WvwMatchSkirmishMapScore> MapScores { get; set; } = Array.Empty<WvwMatchSkirmishMapScore>();
    }
}
