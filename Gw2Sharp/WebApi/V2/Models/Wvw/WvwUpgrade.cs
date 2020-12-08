using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw upgrade.
    /// </summary>
    public class WvwUpgrade : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The upgrade id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The upgrade tiers
        /// </summary>
        public IReadOnlyList<WvwUpgradeTier> Tiers { get; set; } = Array.Empty<WvwUpgradeTier>();
    }
}
