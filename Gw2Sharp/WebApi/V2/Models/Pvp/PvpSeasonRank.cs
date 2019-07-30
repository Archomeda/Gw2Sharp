using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season rank.
    /// </summary>
    public class PvpSeasonRank
    {
        /// <summary>
        /// The rank name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The rank description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The rank icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The rank overlay URL.
        /// </summary>
        public RenderUrl Overlay { get; set; }

        /// <summary>
        /// The small rank overlay URL.
        /// </summary>
        public RenderUrl OverlaySmall { get; set; }

        /// <summary>
        /// The rank tiers.
        /// </summary>
        public IReadOnlyList<PvpSeasonRankTier> Tiers { get; set; } = new List<PvpSeasonRankTier>();
    }
}
