using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild.
    /// </summary>
    public class Guild : ApiV2BaseObject
    {
        /// <summary>
        /// The guild level.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? Level { get; set; }

        /// <summary>
        /// The guild message of the day.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public string? Motd { get; set; }

        /// <summary>
        /// The amount of influence.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? Influence { get; set; }

        /// <summary>
        /// The amount of aetherium.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? Aetherium { get; set; }

        /// <summary>
        /// The amount of resonance.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? Resonance { get; set; }

        /// <summary>
        /// The amount of favor.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? Favor { get; set; }

        /// <summary>
        /// The member count.
        /// Additionally requires scopes: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? MemberCount { get; set; }

        /// <summary>
        /// The member capacity.
        /// Additionally requires scoeps: guilds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public int? MemberCapacity { get; set; }

        /// <summary>
        /// The guild id.
        /// No authentication required.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The guild name.
        /// No authentication required.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The guild tag.
        /// No authentication required.
        /// </summary>
        public string Tag { get; set; } = string.Empty;

        /// <summary>
        /// The guild emblem.
        /// No authentication required.
        /// </summary>
        public GuildEmblem Emblem { get; set; } = new GuildEmblem();
    }
}
