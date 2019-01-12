namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a consumable item.
    /// </summary>
    public class ItemConsumable : Item
    {
        /// <summary>
        /// The consumable details.
        /// </summary>
        public ItemConsumableDetails Details { get; set; } = new ItemConsumableDetails();
    }
}
