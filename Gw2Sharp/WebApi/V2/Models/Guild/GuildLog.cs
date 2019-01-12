using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild log.
    /// The log can be <see cref="GuildLogJoined"/>,
    /// <see cref="GuildLogInvited"/>,
    /// <see cref="GuildLogInviteDeclined"/>,
    /// <see cref="GuildLogKick"/>,
    /// <see cref="GuildLogRankChange"/>,
    /// <see cref="GuildLogMotd"/>,
    /// <see cref="GuildLogStash"/>,
    /// <see cref="GuildLogTreasury"/>,
    /// <see cref="GuildLogUpgrade"/> or
    /// <see cref="GuildLogInfluence"/>.
    /// </summary>
    [CastableType(GuildLogType.Joined, typeof(GuildLogJoined))]
    [CastableType(GuildLogType.Invited, typeof(GuildLogInvited))]
    [CastableType(GuildLogType.InviteDeclined, typeof(GuildLogInviteDeclined))]
    [CastableType(GuildLogType.Kick, typeof(GuildLogKick))]
    [CastableType(GuildLogType.RankChange, typeof(GuildLogRankChange))]
    [CastableType(GuildLogType.Motd, typeof(GuildLogMotd))]
    [CastableType(GuildLogType.Stash, typeof(GuildLogStash))]
    [CastableType(GuildLogType.Treasury, typeof(GuildLogTreasury))]
    [CastableType(GuildLogType.Upgrade, typeof(GuildLogUpgrade))]
    [CastableType(GuildLogType.Influence, typeof(GuildLogInfluence))]
    public class GuildLog : ICastableType<GuildLog, GuildLogType>
    {
        /// <summary>
        /// The guild log id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The guild log time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The guild log type.
        /// </summary>
        public ApiEnum<GuildLogType> Type { get; set; } = new ApiEnum<GuildLogType>();

        /// <summary>
        /// The guild log originating user.
        /// If no user is associated with this log, this value is <c>null</c>.
        /// </summary>
        public string? User { get; set; }
    }
}
