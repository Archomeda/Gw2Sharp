namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the PvP stats aggregate.
    /// </summary>
    public class PvpStatsAggregate
    {
        /// <summary>
        /// The total wins.
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// The total losses.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// The total desertions.
        /// </summary>
        public int Desertions { get; set; }

        /// <summary>
        /// The total byes.
        /// </summary>
        public int Byes { get; set; }

        /// <summary>
        /// The total forfeits.
        /// </summary>
        public int Forfeits { get; set; }
    }
}
