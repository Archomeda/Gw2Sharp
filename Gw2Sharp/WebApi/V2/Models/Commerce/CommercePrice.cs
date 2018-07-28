namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a commerce price.
    /// </summary>
    public class CommercePrice
    {
        /// <summary>
        /// The amount of items listed.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The price of one single item in coins.
        /// </summary>
        public int UnitPrice { get; set; }
    }
}
