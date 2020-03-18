using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a weapon item.
    /// </summary>
    public class ItemWeaponDetails
    {
        /// <summary>
        /// The weapon item type.
        /// </summary>
        public ApiEnum<ItemWeaponType> Type { get; set; } = new ApiEnum<ItemWeaponType>();

        /// <summary>
        /// The damage type.
        /// </summary>
        public ApiEnum<WeaponDamageType> DamageType { get; set; } = new ApiEnum<WeaponDamageType>();

        /// <summary>
        /// The minimum power value.
        /// </summary>
        public int MinPower { get; set; }

        /// <summary>
        /// The maximum power value.
        /// </summary>
        public int MaxPower { get; set; }

        /// <summary>
        /// The defense value.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// The item infusion slots.
        /// </summary>
        public IReadOnlyList<ItemInfusionSlot> InfusionSlots { get; set; } = Array.Empty<ItemInfusionSlot>();

        /// <summary>
        /// The item infix upgrade.
        /// If the item does not have a infix upgrade, this value is <c>null</c>.
        /// </summary>
        public ItemInfixUpgrade? InfixUpgrade { get; set; }

        /// <summary>
        /// The id of the suffix item.
        /// If the item does not have a suffix item, this value is <c>null</c>.
        /// </summary>
        public int? SuffixItemId { get; set; }

        /// <summary>
        /// The id of the secondary suffix item.
        /// If the item does not have a secondary suffix item, this value is <c>null</c>.
        /// </summary>
        [JsonConverter(typeof(StringAsIntConverter))]
        public int? SecondarySuffixItemId { get; set; }

        /// <summary>
        /// The item stat choices.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Itemstats"/>.
        /// </summary>
        public IReadOnlyList<int> StatChoices { get; set; } = Array.Empty<int>();
    }
}
