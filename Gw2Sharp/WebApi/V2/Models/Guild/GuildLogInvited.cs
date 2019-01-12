namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild invitation log.
    /// </summary>
    public class GuildLogInvited : GuildLog
    {
        /// <summary>
        /// The user who sent the invitation.
        /// </summary>
        public string InvitedBy { get; set; } = string.Empty;
    }
}
