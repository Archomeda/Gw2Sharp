namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a container item.
    /// </summary>
    public class ItemContainer : Item
    {
        /// <summary>
        /// The container details.
        /// </summary>
        public ItemContainerDetails Details { get; set; }
    }
}
