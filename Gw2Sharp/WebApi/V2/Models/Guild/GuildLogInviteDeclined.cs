namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild invitation declined log.
    /// </summary>
    public class GuildLogInviteDeclined : GuildLog
    {
        /// <summary>
        /// The user who declined the invitation.
        /// </summary>
        public string DeclinedBy { get; set; }
    }
}
