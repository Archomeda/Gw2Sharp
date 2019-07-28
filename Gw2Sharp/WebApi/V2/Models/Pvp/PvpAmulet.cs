namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP amulet.
    /// </summary>
    public class PvpAmulet : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The amulet id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The amulet name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The amulet icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The amulet attributes.
        /// </summary>
        public ItemAttributes Attributes { get; set; } = new ItemAttributes();
    }
}
