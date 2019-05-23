namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the commerce exchange rate for coins.
    /// </summary>
    public class CommerceExchangeCoins : ApiV2BaseObject
    {
        /// <summary>
        /// The amount of coins required for one gem.
        /// </summary>
        public int CoinsPerGem { get; set; }

        /// <summary>
        /// The amount of gems that are exchanged for the given amount of coins.
        /// </summary>
        public int Quantity { get; set; }
    }
}
