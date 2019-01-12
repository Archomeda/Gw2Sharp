namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a gizmo item.
    /// </summary>
    public class ItemGizmo : Item
    {
        /// <summary>
        /// The gizmo details.
        /// </summary>
        public ItemGizmoDetails Details { get; set; } = new ItemGizmoDetails();
    }
}
