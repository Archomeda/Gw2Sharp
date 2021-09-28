using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the dye slots of an armor skin.
    /// </summary>
    public class SkinArmorDetailsDyeSlots
    {
        /// <summary>
        /// The default dye slots.
        /// If a dye slot isn't available, that element is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<SkinDyeSlot?> Default { get; set; } = Array.Empty<SkinDyeSlot?>();

        /// <summary>
        /// The overridden dye slots.
        /// </summary>
        public SkinArmorDetailsDyeSlotsOverrides Overrides { get; set; } = new SkinArmorDetailsDyeSlotsOverrides();
    }
}
