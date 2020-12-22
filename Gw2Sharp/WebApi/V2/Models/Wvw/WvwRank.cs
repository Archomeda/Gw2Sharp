namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW rank.
    /// </summary>
    public class WvwRank : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The rank id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The rank title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The minimum WvW level required for the rank.
        /// </summary>
        public int MinRank { get; set; }
    }
}
