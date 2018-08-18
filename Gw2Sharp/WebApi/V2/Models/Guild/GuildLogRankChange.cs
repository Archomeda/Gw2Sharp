namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild rank change log.
    /// </summary>
    public class GuildLogRankChange : GuildLog
    {
        /// <summary>
        /// The user who changed the rank.
        /// </summary>
        public string ChangedBy { get; set; }

        /// <summary>
        /// The old rank.
        /// </summary>
        public string OldRank { get; set; }

        /// <summary>
        /// The new rank.
        /// </summary>
        public string NewRank { get; set; }
    }
}
