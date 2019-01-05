namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a trinket item.
    /// </summary>
    public class ItemTrinket : Item
    {
        /// <summary>
        /// The trinket details.
        /// </summary>
        public ItemTrinketDetails Details { get; set; }
    }
}
