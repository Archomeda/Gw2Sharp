using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild upgrade.
    /// The guild upgrade can be <see cref="GuildUpgradeAccumulatingCurrency"/>,
    /// <see cref="GuildUpgradeBankBag"/>,
    /// <see cref="GuildUpgradeBoost"/>,
    /// <see cref="GuildUpgradeClaimable"/>,
    /// <see cref="GuildUpgradeConsumable"/>,
    /// <see cref="GuildUpgradeDecoration"/>,
    /// <see cref="GuildUpgradeGuildHall"/>,
    /// <see cref="GuildUpgradeGuildHallExpedition"/>,
    /// <see cref="GuildUpgradeHub"/>,
    /// <see cref="GuildUpgradeUnlock"/> or
    /// <see cref="GuildUpgradeQueue"/>
    /// </summary>
    [CastableType(GuildUpgradeType.AccumulatingCurrency, typeof(GuildUpgradeAccumulatingCurrency))]
    [CastableType(GuildUpgradeType.BankBag, typeof(GuildUpgradeBankBag))]
    [CastableType(GuildUpgradeType.Boost, typeof(GuildUpgradeBoost))]
    [CastableType(GuildUpgradeType.Claimable, typeof(GuildUpgradeClaimable))]
    [CastableType(GuildUpgradeType.Consumable, typeof(GuildUpgradeConsumable))]
    [CastableType(GuildUpgradeType.Decoration, typeof(GuildUpgradeDecoration))]
    [CastableType(GuildUpgradeType.GuildHall, typeof(GuildUpgradeGuildHall))]
    [CastableType(GuildUpgradeType.GuildHallExpedition, typeof(GuildUpgradeGuildHallExpedition))]
    [CastableType(GuildUpgradeType.Hub, typeof(GuildUpgradeHub))]
    [CastableType(GuildUpgradeType.Unlock, typeof(GuildUpgradeUnlock))]
    [CastableType(GuildUpgradeType.Queue, typeof(GuildUpgradeQueue))]
    public class GuildUpgrade : ApiV2BaseObject, ICastableType<GuildUpgrade, GuildUpgradeType>, IIdentifiable<int>
    {
        /// <summary>
        /// The guild upgrade id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The guild upgrade name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The guild upgrade description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The guild upgrade build time.
        /// </summary>
        public int BuildTime { get; set; }

        /// <summary>
        /// The guild upgrade icon.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The guild upgrade type.
        /// </summary>
        public ApiEnum<GuildUpgradeType> Type { get; set; } = new ApiEnum<GuildUpgradeType>();

        /// <summary>
        /// The guild upgrade required level.
        /// </summary>
        public int RequiredLevel { get; set; }

        /// <summary>
        /// The guild upgrade experience.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// The guild upgrade prerequisites.
        /// Each element can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public IReadOnlyList<int> Prerequisites { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The guild upgrade costs.
        /// </summary>
        public IReadOnlyList<GuildUpgradeCost> Costs { get; set; } = Array.Empty<GuildUpgradeCost>();
    }
}
