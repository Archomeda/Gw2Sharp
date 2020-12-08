using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match.
    /// </summary>
    public class WvwMatch : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The match id
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The match start time
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The match end time
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The gained scores by color
        /// </summary>
        public WvwMatchWorldValueContainer? Scores { get; set; }

        /// <summary>
        /// The participating host worlds (represented by their id) by color
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>
        /// </summary>
        public WvwMatchWorldValueContainer? Worlds { get; set; }

        /// <summary>
        /// The participating worlds (represented by their id) by color
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>
        /// </summary>
        public WvwMatchWorldIdContainer? AllWorlds { get; set; }

        /// <summary>
        /// The occured kills by color
        /// </summary>
        public WvwMatchWorldValueContainer? Kills { get; set; }

        /// <summary>
        /// The occured deaths by color
        /// </summary>
        public WvwMatchWorldValueContainer? Deaths { get; set; }

        /// <summary>
        /// The gained victory points by color
        /// </summary>
        public WvwMatchWorldValueContainer? VictoryPoints { get; set; }

        /// <summary>
        /// The match map states
        /// </summary>
        public IReadOnlyList<WvwMatchMap> Maps { get; set; } = Array.Empty<WvwMatchMap>();

        /// <summary>
        /// The match skirmishes
        /// </summary>
        public IReadOnlyList<WvwMatchSkirmish> Skirmishes { get; set; } = Array.Empty<WvwMatchSkirmish>();


    }
}
