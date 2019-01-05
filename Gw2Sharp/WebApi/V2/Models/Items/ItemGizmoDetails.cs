namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a gizmo item.
    /// </summary>
    public class ItemGizmoDetails
    {
        /// <summary>
        /// The gizmo item type.
        /// </summary>
        public ApiEnum<ItemGizmoType> Type { get; set; }
    }
}
