using System.Collections.Generic;

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
        public IReadOnlyList<ApiEnum<ItemInfusionFlag>> Flags { get; set; }

        /// <summary>
        /// The infusion item id.
        /// If the item has no infusions, this value is <c>null</c>.
        /// </summary>
        public int? ItemId { get; set; }
    }
}
