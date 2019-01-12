namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild message of the day log.
    /// </summary>
    public class GuildLogMotd : GuildLog
    {
        /// <summary>
        /// The new message of the day.
        /// </summary>
        public string Motd { get; set; } = string.Empty;
    }
}
