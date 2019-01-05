namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mini pet item.
    /// </summary>
    public class ItemMiniPet : Item
    {
        /// <summary>
        /// The mini pet details.
        /// </summary>
        public ItemMiniPetDetails Details { get; set; }
    }
}
