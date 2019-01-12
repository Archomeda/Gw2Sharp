using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of an upgrade component item.
    /// </summary>
    public class ItemUpgradeComponentDetails
    {
        /// <summary>
        /// The item upgrade component type.
        /// </summary>
        public ApiEnum<ItemUpgradeComponentType> Type { get; set; } = new ApiEnum<ItemUpgradeComponentType>();

        /// <summary>
        /// The item upgrade component flags.
        /// </summary>
        public ApiFlags<ItemUpgradeComponentFlag> Flags { get; set; } = new ApiFlags<ItemUpgradeComponentFlag>();

        /// <summary>
        /// The item infusion flags.
        /// </summary>
        public ApiFlags<ItemInfusionFlag> InfusionUpgradeFlags { get; set; } = new ApiFlags<ItemInfusionFlag>();

        /// <summary>
        /// The item suffix.
        /// </summary>
        public string Suffix { get; set; } = string.Empty;

        /// <summary>
        /// The item infix upgrade.
        /// If the item does not have a infix upgrade, this value is <c>null</c>.
        /// </summary>
        public ItemInfixUpgrade? InfixUpgrade { get; set; }

        /// <summary>
        /// The item bonuses in case the item is a rune, check <see cref="Type"/>.
        /// If the item is not a rune, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<string>? Bonuses { get; set; }
    }
}
