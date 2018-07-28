namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a commerce listing.
    /// </summary>
    public class CommerceListing
    {
        /// <summary>
        /// The amount of player listings.
        /// </summary>
        public int Listings { get; set; }

        /// <summary>
        /// The price of one single item in coins.
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// The amount of items listed.
        /// </summary>
        public int Quantity { get; set; }
    }
}
