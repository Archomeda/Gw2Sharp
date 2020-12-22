using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW ability.
    /// </summary>
    public class WvwAbility : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The ability id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ability name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The ability description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The ability icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The ability ranks.
        /// </summary>
        public IReadOnlyList<WvwAbilityRank> Ranks { get; set; } = Array.Empty<WvwAbilityRank>();
    }
}
