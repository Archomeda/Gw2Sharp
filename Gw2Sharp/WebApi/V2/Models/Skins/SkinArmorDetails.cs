namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of an armor skin.
    /// </summary>
    public class SkinArmorDetails
    {
        /// <summary>
        /// The armor skin slot type.
        /// </summary>
        public ApiEnum<ItemArmorSlotType> Type { get; set; } = new ApiEnum<ItemArmorSlotType>();

        /// <summary>
        /// The armor skin weight class.
        /// </summary>
        public ApiEnum<ItemWeightType> WeightClass { get; set; } = new ApiEnum<ItemWeightType>();

        /// <summary>
        /// The armor skin dye slots.
        /// </summary>
        public SkinArmorDetailsDyeSlots DyeSlots { get; set; } = new SkinArmorDetailsDyeSlots();
    }
}
