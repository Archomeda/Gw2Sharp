using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a glider.
    /// </summary>
    public class Glider : IIdentifiable<int>
    {
        /// <summary>
        /// The glider id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The items that unlock this glider.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItems { get; set; }

        /// <summary>
        /// The glider order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The glider icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The glider name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The glider unlock details.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The glider default dyes.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        public IReadOnlyList<int> DefaultDyes { get; set; }
    }
}
