namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an armor item.
    /// </summary>
    public class ItemArmor : Item
    {
        /// <summary>
        /// The armor details.
        /// </summary>
        public ItemArmorDetails Details { get; set; } = new ItemArmorDetails();
    }
}
