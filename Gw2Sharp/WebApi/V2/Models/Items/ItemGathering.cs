namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a gathering tool item.
    /// </summary>
    public class ItemGathering : Item
    {
        /// <summary>
        /// The gathering tool details.
        /// </summary>
        public ItemGatheringDetails Details { get; set; } = new ItemGatheringDetails();
    }
}
