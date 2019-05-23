namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the commerce exchange rate for gems.
    /// </summary>
    public class CommerceExchangeGems : ApiV2BaseObject
    {
        /// <summary>
        /// The amount of coins required for one gem.
        /// </summary>
        public int CoinsPerGem { get; set; }

        /// <summary>
        /// The amount of coins that are exchanged for the given amount of gems.
        /// </summary>
        public int Quantity { get; set; }
    }
}
