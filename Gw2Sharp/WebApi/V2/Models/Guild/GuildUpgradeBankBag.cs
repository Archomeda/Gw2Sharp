namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild bank bag upgrade.
    /// </summary>
    public class GuildUpgradeBankBag : GuildUpgrade
    {
        /// <summary>
        /// The maximum amount of items that can be stored.
        /// </summary>
        public int BagMaxItems { get; set; }

        /// <summary>
        /// The maximum amount of coins that can be stored.
        /// </summary>
        public int BagMaxCoins { get; set; }
    }
}
