using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw Skirmish map score.
    /// </summary>
    public class WvwMatchSkirmishMapScore : ApiV2BaseObject
    {
        /// <summary>
        /// The type of the map
        /// </summary>
        public ApiEnum<WvwMapType> Type { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// the scores of the map by color
        /// </summary>
        public WvwMatchWorldValueContainer? Scores { get; set; }
    }
}
