using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild treasury item upgrade.
    /// </summary>
    public class GuildTreasuryItemUpgrade
    {
        /// <summary>
        /// The upgrade id.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public int UpgradeId { get; set; }

        /// <summary>
        /// The amount of items required for this upgrade.
        /// </summary>
        public int Count { get; set; }
    }
}
