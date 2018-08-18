using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild upgrade log.
    /// </summary>
    public class GuildLogUpgrade : GuildLog
    {
        /// <summary>
        /// The upgrade action.
        /// </summary>
        public ApiEnum<GuildLogUpgradeAction> Action { get; set; }

        /// <summary>
        /// The upgrade id.
        /// Can be resolved against <see cref="IGuildClient.Upgrades"/>.
        /// </summary>
        public int UpgradeId { get; set; }

        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// If no item is associated with this upgrade, this value is null.
        /// </summary>
        public int? ItemId { get; set; }

        /// <summary>
        /// The recipe id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// If no recipe is associated with this upgrade, this value is null.
        /// </summary>
        public int? RecipeId { get; set; }

        /// <summary>
        /// The amount of items.
        /// If no item is associated with this upgrade, this value is null.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// The amount of coins.
        /// </summary>
        public int Coins { get; set; }
    }
}
