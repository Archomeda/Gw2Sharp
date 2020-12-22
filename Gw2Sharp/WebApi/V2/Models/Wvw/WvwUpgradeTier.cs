using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW upgrade tier.
    /// </summary>
    public class WvwUpgradeTier : ApiV2BaseObject
    {
        /// <summary>
        /// The upgrade tier name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The number of dolyaks required to reach this tier.
        /// </summary>
        public int YaksRequired { get; set; }

        /// <summary>
        /// The available upgrades for this tier.
        /// </summary>
        public IReadOnlyList<WvwUpgradeTierUpgrade> Upgrades { get; set; } = Array.Empty<WvwUpgradeTierUpgrade>();
    }
}
