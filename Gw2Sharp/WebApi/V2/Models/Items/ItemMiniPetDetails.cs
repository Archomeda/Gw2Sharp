namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a mini pet item.
    /// </summary>
    public class ItemMiniPetDetails
    {
        /// <summary>
        /// The mini pet item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Minis"/>.
        /// </summary>
        public int MinipetId { get; set; }
    }
}
