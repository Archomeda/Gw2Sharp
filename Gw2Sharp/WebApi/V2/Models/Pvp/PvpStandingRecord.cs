namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP standing record.
    /// </summary>
    public class PvpStandingRecord : ApiV2BaseObject
    {
        /// <summary>
        /// The PvP standing record total points.
        /// </summary>
        public int TotalPoints { get; set; }

        /// <summary>
        /// The PvP standing record division.
        /// </summary>
        public int Division { get; set; }

        /// <summary>
        /// The PvP standing record tier.
        /// </summary>
        public int Tier { get; set; }

        /// <summary>
        /// The PvP standing record points.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// The PvP standing record repeats.
        /// </summary>
        public int Repeats { get; set; }

        /// <summary>
        /// The PvP standing rating.
        /// This value is <see langword="null"/> when the record doesn't track the rating.
        /// </summary>
        public int? Rating { get; set; }
    }
}
