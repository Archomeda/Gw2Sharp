namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an item infusion slot.
    /// </summary>
    public class ItemInfusionSlot
    {
        /// <summary>
        /// The infusion type flags.
        /// </summary>
        public ApiFlags<ItemInfusionFlag> Flags { get; set; } = new ApiFlags<ItemInfusionFlag>();

        /// <summary>
        /// The infusion item id.
        /// If the item has no infusions, this value is <see langword="null"/>.
        /// </summary>
        public int? ItemId { get; set; }
    }
}
