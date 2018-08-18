namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the PvP stats ladders.
    /// </summary>
    public class PvpStatsLadders
    {
        /// <summary>
        /// The unranked ladder.
        /// If no unranked ladder is available, this value is null.
        /// </summary>
        public PvpStatsAggregate Unranked { get; set; }

        /// <summary>
        /// The ranked ladder.
        /// If no ranked ladder is available, this value is null.
        /// </summary>
        public PvpStatsAggregate Ranked { get; set; }
    }
}
