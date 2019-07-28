namespace Gw2Sharp.WebApi.V2.Models
{
    public class PvpRankLevel
    {
        /// <summary>
        /// The minimum PvP level this is valid for.
        /// </summary>
        public int MinRank { get; set; }

        /// <summary>
        /// The maxmimum PvP level this is valid for.
        /// </summary>
        public int MaxRank { get; set; }

        /// <summary>
        /// The points required per level for this range.
        /// </summary>
        public int Points { get; set; }
    }
}
