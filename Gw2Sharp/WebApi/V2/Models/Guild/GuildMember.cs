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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The guild member rank.
        /// </summary>
        public string Rank { get; set; } = string.Empty;

        /// <summary>
        /// The time the guild member joined.
        /// If the member joined before this was tracked, this value is <c>null</c>.
        /// </summary>
        public DateTime? Joined { get; set; }
    }
}
