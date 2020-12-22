using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW match map objective.
    /// </summary>
    public class WvwMatchMapObjective : ApiV2BaseObject
    {
        /// <summary>
        /// The objective id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The objective type.
        /// </summary>
        public ApiEnum<WvwObjectiveType> Type { get; set; } = new ApiEnum<WvwObjectiveType>();

        /// <summary>
        /// The objective owner.
        /// </summary>
        public ApiEnum<WvwOwner> Owner { get; set; } = new ApiEnum<WvwOwner>();

        /// <summary>
        /// The timestamp of when the last time a change of ownership has occurred.
        /// </summary>
        public DateTime? LastFlipped { get; set; }

        /// <summary>
        /// The id of the guild that has claimed the objective.
        /// If no guild has claimed the objective, this value is <c>null</c>.
        /// </summary>
        public Guid? ClaimedBy { get; set; }

        /// <summary>
        /// The timestamp of when the objective has been claimed.
        /// If no guild has claimed the objective, this value is <c>null</c>.
        /// </summary>
        public DateTime? ClaimedAt { get; set; }

        /// <summary>
        /// The number of points that are generated per tick.
        /// </summary>
        public int PointsTick { get; set; }

        /// <summary>
        /// The number of points that will be generated at capture.
        /// </summary>
        public int PointsCapture { get; set; }

        /// <summary>
        /// The number of dolyaks delivered to the objective.
        /// </summary>
        public int? YaksDelivered { get; set; }

        /// <summary>
        /// The list of guild upgrade ids.
        /// Each element can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public IReadOnlyList<int> GuildUpgrades { get; set; } = Array.Empty<int>();
    }
}
