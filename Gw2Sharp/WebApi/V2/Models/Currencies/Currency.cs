namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a currency.
    /// </summary>
    public class Currency : IIdentifiable<int>
    {
        /// <summary>
        /// The currency id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The currency name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The currency description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The currency order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The currency icon.
        /// </summary>
        public string Icon { get; set; } = string.Empty;
    }
}
