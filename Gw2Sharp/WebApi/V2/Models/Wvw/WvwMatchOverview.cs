using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the overview of a WvW match.
    /// </summary>
    public class WvwMatchOverview : ApiV2BaseObject, IIdentifiable<string>
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
        /// The participating host worlds (represented by their id) per team.
        /// Each id can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>.
        /// </summary>
        public WvwMatchTeamValues Worlds { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// All participating worlds (represented by their id) per team.
        /// Each id can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>.
        /// </summary>
        public WvwMatchTeamList AllWorlds { get; set; } = new WvwMatchTeamList();
    }
}
