namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents commerce delivery item.
    /// </summary>
    public class CommerceDeliveryItem
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The amount of items.
        /// </summary>
        public int Count { get; set; }
    }
}
