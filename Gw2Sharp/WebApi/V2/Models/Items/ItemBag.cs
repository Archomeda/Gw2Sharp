namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a bag item.
    /// </summary>
    public class ItemBag : Item
    {
        /// <summary>
        /// The bag details.
        /// </summary>
        public ItemBagDetails Details { get; set; } = new ItemBagDetails();
    }
}
