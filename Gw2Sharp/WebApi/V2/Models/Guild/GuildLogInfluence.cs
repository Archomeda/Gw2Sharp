using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild influence log.
    /// </summary>
    public class GuildLogInfluence : GuildLog
    {
        /// <summary>
        /// The influence activity.
        /// </summary>
        public ApiEnum<GuildLogInfluenceActivity> Activity { get; set; } = new ApiEnum<GuildLogInfluenceActivity>();

        /// <summary>
        /// The total amount of participants.
        /// </summary>
        public int TotalParticipants { get; set; }

        /// <summary>
        /// The participating users.
        /// </summary>
        public IReadOnlyList<string> Participants { get; set; } = new List<string>();
    }
}
