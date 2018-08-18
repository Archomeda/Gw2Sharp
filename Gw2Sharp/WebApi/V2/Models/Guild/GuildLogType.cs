using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The guild log type.
    /// </summary>
    public enum GuildLogType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// A user joined the guild.
        /// </summary>
        Joined,

        /// <summary>
        /// A user was invited to the guild.
        /// </summary>
        Invited,

        /// <summary>
        /// A user declined the invitation to the guild.
        /// </summary>
        [EnumMember(Value = "invite_declined")]
        InviteDeclined,

        /// <summary>
        /// A user was kicked from the guild.
        /// </summary>
        Kick,

        /// <summary>
        /// A user's guild rank was changed.
        /// </summary>
        [EnumMember(Value = "rank_change")]
        RankChange,

        /// <summary>
        /// The guild message of the day was changed.
        /// </summary>
        Motd,

        /// <summary>
        /// An item was deposited in or withdrawn from the guild stash.
        /// </summary>
        Stash,

        /// <summary>
        /// An item was deposited in the guild treasury.
        /// </summary>
        Treasury,

        /// <summary>
        /// A guild upgrade was executed.
        /// </summary>
        Upgrade,

        /// <summary>
        /// Influence was added to the guild.
        /// </summary>
        Influence
    }
}
