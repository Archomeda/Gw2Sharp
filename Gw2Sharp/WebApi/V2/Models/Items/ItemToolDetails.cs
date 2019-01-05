namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a tool item.
    /// </summary>
    public class ItemToolDetails
    {
        /// <summary>
        /// The tool item type.
        /// </summary>
        public ApiEnum<ItemToolType> Type { get; set; }

        /// <summary>
        /// The remaining charges.
        /// </summary>
        public int Charges { get; set; }
    }
}
