namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild kick log.
    /// </summary>
    public class GuildLogKick : GuildLog
    {
        /// <summary>
        /// The user who did the kicking.
        /// </summary>
        public string KickedBy { get; set; } = string.Empty;
    }
}
