using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP hero skin.
    /// </summary>
    public class PvpHeroSkin
    {
        /// <summary>
        /// The hero skin id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The hero skin name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The hero skin icon.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// Whether this hero skin is the default one.
        /// </summary>
        public bool Default { get; set; }

        /// <summary>
        /// The items that unlock this hero skin.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItems { get; set; } = Array.Empty<int>();
    }
}
