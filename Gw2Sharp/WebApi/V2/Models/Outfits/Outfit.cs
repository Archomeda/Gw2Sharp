using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an outfit.
    /// </summary>
    public class Outfit : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The outfit id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The outfit name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The items that unlock this outfit.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItems { get; set; } = new List<int>();
    }
}
