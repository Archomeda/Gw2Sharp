using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match map objective.
    /// </summary>
    public class WvwMatchMapObjective : ApiV2BaseObject
    {
        /// <summary>
        /// The objective id
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The objective type
        /// </summary>
        public ApiEnum<WvwObjectiveType> Type { get; set; } = new ApiEnum<WvwObjectiveType>();

        /// <summary>
        /// The objective owner
        /// </summary>
        public ApiEnum<WvwOwner> Owner { get; set; } = new ApiEnum<WvwOwner>();

        /// <summary>
        /// timestamp of last owner flip
        /// </summary>
        public DateTime? LastFlipped { get; set; }

        /// <summary>
        /// Guild id if claimed, null if unclaimed
        /// </summary>
        public Guid? ClaimedBy { get; set; }

        /// <summary>
        /// Timestamp of guild claim, null if unclaimed
        /// </summary>
        public DateTime? ClaimedAt { get; set; }

        /// <summary>
        /// Number of points generated per tick
        /// </summary>
        public int PointsTick { get; set; }

        /// <summary>
        /// Number of points generated at capture
        /// </summary>
        public int PointsCapture { get; set; }

        /// <summary>
        /// Number of pack dolyaks delivered to the objective
        /// </summary>
        public int? YaksDelivered { get; set; }

        /// <summary>
        /// The guild upgrade ids
        /// </summary>
        public IReadOnlyList<int> GuildUpgrades { get; set; } = Array.Empty<int>();
    }
}
