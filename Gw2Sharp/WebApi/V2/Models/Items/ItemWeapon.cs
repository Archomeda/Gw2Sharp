namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a weapon item.
    /// </summary>
    public class ItemWeapon : Item
    {
        /// <summary>
        /// The weapon details.
        /// </summary>
        public ItemWeaponDetails Details { get; set; } = new ItemWeaponDetails();
    }
}
