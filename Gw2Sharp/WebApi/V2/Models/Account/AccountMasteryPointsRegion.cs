namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the a region of the mastery points.
    /// </summary>
    public class AccountMasteryPointsRegion
    {
        /// <summary>
        /// The region id.
        /// </summary>
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// The total amount of mastery points spent for this region.
        /// </summary>
        public int Spent { get; set; }

        /// <summary>
        /// The total amount of mastery points earned for this region.
        /// </summary>
        public int Earned { get; set; }
    }
}
