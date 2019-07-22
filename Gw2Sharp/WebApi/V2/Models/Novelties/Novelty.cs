using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a novelty.
    /// </summary>
    public class Novelty : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The novelty id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The novelty name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The novelty description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The novelty slot.
        /// </summary>
        public NoveltySlot Slot { get; set; }

        /// <summary>
        /// The items that unlock this novelty.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItem { get; set; } = new List<int>();
    }
}
