using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw Ability.
    /// </summary>
    public class WvwAbility : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The ability id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ability name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The ability description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The render url of the ability icon
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// The Ability ranks
        /// </summary>
        public IReadOnlyList<WvwAbilityRank> Ranks { get; set; } = Array.Empty<WvwAbilityRank>();
    }
}
