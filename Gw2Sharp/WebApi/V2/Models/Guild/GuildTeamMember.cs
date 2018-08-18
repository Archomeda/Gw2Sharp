namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild team member.
    /// </summary>
    public class GuildTeamMember
    {
        /// <summary>
        /// The member name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The member role.
        /// </summary>
        public ApiEnum<GuildTeamMemberRole> Role { get; set; }
    }
}
