using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW match.
    /// </summary>
    public class WvwMatch : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The match id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The match start time.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The match end time.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// The team scores.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The participating host worlds (represented by their id) per team.
        /// Each id can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>.
        /// </summary>
        public WvwMatchTeamValues Worlds { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// All participating worlds (represented by their id) per team.
        /// Each id can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>.
        /// </summary>
        public WvwMatchTeamList AllWorlds { get; set; } = new WvwMatchTeamList();

        /// <summary>
        /// The number of kills per team.
        /// </summary>
        public WvwMatchTeamValues Kills { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The number of deaths per team.
        /// </summary>
        public WvwMatchTeamValues Deaths { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The number of gained victory points per team.
        /// </summary>
        public WvwMatchTeamValues VictoryPoints { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The match map states.
        /// </summary>
        public IReadOnlyList<WvwMatchMap> Maps { get; set; } = Array.Empty<WvwMatchMap>();

        /// <summary>
        /// The match skirmishes.
        /// </summary>
        public IReadOnlyList<WvwMatchSkirmish> Skirmishes { get; set; } = Array.Empty<WvwMatchSkirmish>();
    }
}
