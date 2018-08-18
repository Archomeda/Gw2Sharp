using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild member.
    /// </summary>
    public class GuildMember
    {
        /// <summary>
        /// The guild member name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The guild member rank.
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// The time the guild member joined.
        /// If the member joined before this was tracked, this value is null.
        /// </summary>
        public DateTime? Joined { get; set; }
    }
}
