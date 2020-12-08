using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match skirmish.
    /// </summary>
    public class WvwMatchSkirmish : ApiV2BaseObject
    {
        /// <summary>
        /// The ability id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Skirmish score by color
        /// </summary>
        public WvwMatchWorldValueContainer? Scores { get; set; }

        /// <summary>
        /// Map Scores
        /// </summary>
        public IReadOnlyList<WvwMatchSkirmishMapScore> MapScores { get; set; } = Array.Empty<WvwMatchSkirmishMapScore>();
    }
}
