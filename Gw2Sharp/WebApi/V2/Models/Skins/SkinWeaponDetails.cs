namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a weapon skin.
    /// </summary>
    public class SkinWeaponDetails
    {
        /// <summary>
        /// The weapon skin type.
        /// </summary>
        public ApiEnum<ItemWeaponType> Type { get; set; } = new ApiEnum<ItemWeaponType>();

        /// <summary>
        /// The weapon skin damage type.
        /// </summary>
        public ApiEnum<WeaponDamageType> DamageType { get; set; } = new ApiEnum<WeaponDamageType>();
    }
}
