namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a weapon skin.
    /// </summary>
    public class SkinWeapon : Skin
    {
        /// <summary>
        /// The weapon details.
        /// </summary>
        public SkinWeaponDetails Details { get; set; } = new SkinWeaponDetails();
    }
}
