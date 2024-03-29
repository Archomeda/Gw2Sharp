using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a trinket item.
    /// </summary>
    public class ItemTrinketDetails
    {
        /// <summary>
        /// The item trinket type.
        /// </summary>
        public ApiEnum<ItemTrinketType> Type { get; set; } = new ApiEnum<ItemTrinketType>();

        /// <summary>
        /// The item infusion slots.
        /// </summary>
        public IReadOnlyList<ItemInfusionSlot> InfusionSlots { get; set; } = Array.Empty<ItemInfusionSlot>();

        /// <summary>
        /// The item attribute adjustment value.
        /// </summary>
        public double AttributeAdjustment { get; set; }

        /// <summary>
        /// The item infix upgrade.
        /// If the item does not have a infix upgrade, this value is <see langword="null"/>.
        /// </summary>
        public ItemInfixUpgrade? InfixUpgrade { get; set; }

        /// <summary>
        /// The id of the suffix item.
        /// If the item does not have a suffix item, this value is <see langword="null"/>.
        /// </summary>
        public int? SuffixItemId { get; set; }

        /// <summary>
        /// The id of the secondary suffix item.
        /// If the item does not have a secondary suffix item, this value is <see langword="null"/>.
        /// </summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>
        /// The item stat choices.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Itemstats"/>.
        /// </summary>
        public IReadOnlyList<int> StatChoices { get; set; } = Array.Empty<int>();
    }
}
