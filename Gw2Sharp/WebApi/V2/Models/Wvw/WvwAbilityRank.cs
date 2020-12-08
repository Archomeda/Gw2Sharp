using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw Ability.
    /// </summary>
    public class WvwAbilityRank : ApiV2BaseObject
    {
        /// <summary>
        /// The point cost of this rank
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The effect description of this ability rank
        /// </summary>
        public string Effect { get; set; } = string.Empty;

    }
}
