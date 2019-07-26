namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mini.
    /// </summary>
    public class Mini : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The mini id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mini name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mini icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The material category order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The item id of this mini.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }
    }
}
