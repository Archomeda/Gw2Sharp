namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a tool item.
    /// </summary>
    public class ItemTool : Item
    {
        /// <summary>
        /// The tool details.
        /// </summary>
        public ItemToolDetails Details { get; set; } = new ItemToolDetails();
    }
}
