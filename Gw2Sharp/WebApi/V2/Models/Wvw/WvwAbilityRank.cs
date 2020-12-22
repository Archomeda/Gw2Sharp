namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW ability rank.
    /// </summary>
    public class WvwAbilityRank : ApiV2BaseObject
    {
        /// <summary>
        /// The ability rank point cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The ability rank effect description.
        /// </summary>
        public string Effect { get; set; } = string.Empty;
    }
}
