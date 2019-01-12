namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a upgrade component item.
    /// </summary>
    public class ItemUpgradeComponent : Item
    {
        /// <summary>
        /// The upgrade component details.
        /// </summary>
        public ItemUpgradeComponentDetails Details { get; set; } = new ItemUpgradeComponentDetails();
    }
}
