using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mount skin.
    /// </summary>
    public class MountSkin : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The mount skin id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mount skin name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mount skin icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The mount skin dye slots.
        /// </summary>
        public IReadOnlyList<SkinDyeSlot> DyeSlots { get; set; } = Array.Empty<SkinDyeSlot>();

        /// <summary>
        /// The mount type.
        /// Can be resolved against <see cref="IMountsClient.Types"/>.
        /// </summary>
        public string Mount { get; set; } = string.Empty;
    }
}
