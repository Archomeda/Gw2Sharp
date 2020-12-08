using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw upgrade tier upgrade.
    /// </summary>
    public class WvwUpgradeTierUpgrade : ApiV2BaseObject
    {
        /// <summary>
        /// The upgrade name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The upgrade description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The render url of the upgrade icon
        /// </summary>
        public string Icon { get; set; } = string.Empty;

    }
}
