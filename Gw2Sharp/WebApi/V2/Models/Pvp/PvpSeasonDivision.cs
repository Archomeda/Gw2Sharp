using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season division.
    /// </summary>
    public class PvpSeasonDivision
    {
        /// <summary>
        /// The division name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The division flags.
        /// </summary>
        public ApiFlags<PvpSeasonDivisionFlag> Flags { get; set; } = new ApiFlags<PvpSeasonDivisionFlag>();

        /// <summary>
        /// The division large icon URL.
        /// </summary>
        public RenderUrl LargeIcon { get; set; }

        /// <summary>
        /// The division small icon URL.
        /// </summary>
        public RenderUrl SmallIcon { get; set; }

        /// <summary>
        /// The division pip icon.
        /// </summary>
        public RenderUrl PipIcon { get; set; }

        /// <summary>
        /// The division tiers.
        /// </summary>
        public IReadOnlyList<PvpSeasonDivisionTier> Tiers { get; set; } = new List<PvpSeasonDivisionTier>();
    }
}
