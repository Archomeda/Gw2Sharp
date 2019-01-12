namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represent a guild upgrade cost.
    /// The upgrade cost can be <see cref="GuildUpgradeCostCoins"/>, <see cref="GuildUpgradeCostCollectible"/>, <see cref="GuildUpgradeCostCurrency"/> or <see cref="GuildUpgradeCostItem"/>.
    /// </summary>
    [CastableType(GuildUpgradeCostType.Coins, typeof(GuildUpgradeCostCoins))]
    [CastableType(GuildUpgradeCostType.Collectible, typeof(GuildUpgradeCostCollectible))]
    [CastableType(GuildUpgradeCostType.Currency, typeof(GuildUpgradeCostCurrency))]
    [CastableType(GuildUpgradeCostType.Item, typeof(GuildUpgradeCostItem))]
    public class GuildUpgradeCost : ICastableType<GuildUpgradeCost, GuildUpgradeCostType>
    {
        /// <summary>
        /// The cost type.
        /// </summary>
        public ApiEnum<GuildUpgradeCostType> Type { get; set; } = new ApiEnum<GuildUpgradeCostType>();

        /// <summary>
        /// The amount needed.
        /// </summary>
        public int Count { get; set; }
    }
}
