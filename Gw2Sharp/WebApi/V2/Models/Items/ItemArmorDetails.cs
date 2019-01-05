using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of an armor item.
    /// </summary>
    public class ItemArmorDetails
    {
        /// <summary>
        /// The item details type.
        /// </summary>
        public ApiEnum<ItemArmorSlotType> Type { get; set; }

        /// <summary>
        /// The item weight class type.
        /// </summary>
        public ApiEnum<ItemWeightType> WeightClass { get; set; }

        /// <summary>
        /// The item defense value.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// The item infusion slots.
        /// </summary>
        public IReadOnlyList<ItemInfusionSlot> InfusionSlots { get; set; }

        /// <summary>
        /// The item infix upgrade.
        /// If the item does not have a infix upgrade, this value is <c>null</c>.
        /// </summary>
        public ItemInfixUpgrade InfixUpgrade { get; set; }

        /// <summary>
        /// The id of the suffix item.
        /// If the item does not have a suffix item, this value is <c>null</c>.
        /// </summary>
        public int? SuffixItemId { get; set; }

        /// <summary>
        /// The id of the secondary suffix item.
        /// If the item does not have a secondary suffix item, this value is <c>null</c>.
        /// </summary>
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>
        /// The item stat choices.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.ItemStats"/>.
        /// </summary>
        public IReadOnlyList<int> StatChoices { get; set; }
    }
}
