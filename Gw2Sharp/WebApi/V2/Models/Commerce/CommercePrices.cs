namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the commerce prices of an item.
    /// </summary>
    public class CommercePrices : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Whether a play for free account has access to this item through commerce.
        /// </summary>
        public bool Whitelisted { get; set; }

        /// <summary>
        /// The buy price information.
        /// </summary>
        public CommercePrice Buys { get; set; } = new CommercePrice();

        /// <summary>
        /// The sell price information
        /// </summary>
        public CommercePrice Sells { get; set; } = new CommercePrice();
    }
}
