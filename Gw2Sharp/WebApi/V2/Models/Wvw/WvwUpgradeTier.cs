using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw upgrade tier.
    /// </summary>
    public class WvwUpgradeTier : ApiV2BaseObject
    {
        /// <summary>
        /// The tiers' name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The number of pack dolyaks required to reach this tier
        /// </summary>
        public int YaksRequired { get; set; }

        /// <summary>
        /// The tiers' available upgrades
        /// </summary>
        public IReadOnlyList<WvwUpgradeTierUpgrade> Upgrades { get; set; } = Array.Empty<WvwUpgradeTierUpgrade>();
    }
}
