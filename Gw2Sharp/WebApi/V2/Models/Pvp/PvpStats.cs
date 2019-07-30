using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents PvP stats.
    /// </summary>
    public class PvpStats : ApiV2BaseObject
    {
        /// <summary>
        /// The PvP rank.
        /// </summary>
        public int PvpRank { get; set; }

        /// <summary>
        /// The PvP rank points.
        /// </summary>
        public int PvpRankPoints { get; set; }

        /// <summary>
        /// The PvP rank rollovers.
        /// </summary>
        public int PvpRankRollovers { get; set; }

        /// <summary>
        /// The aggregate stats.
        /// </summary>
        public PvpStatsAggregate Aggregate { get; set; } = new PvpStatsAggregate();

        /// <summary>
        /// The profession aggregate stats.
        /// </summary>
        public IReadOnlyDictionary<string, PvpStatsAggregate> Professions { get; set; } = new Dictionary<string, PvpStatsAggregate>();

        /// <summary>
        /// The ladders aggregate stats.
        /// </summary>
        public IReadOnlyDictionary<string, PvpStatsAggregate> Ladders { get; set; } = new Dictionary<string, PvpStatsAggregate>();
    }
}
