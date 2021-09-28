namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A buff trait fact.
    /// </summary>
    public class TraitFactBuff : TraitFact
    {
        /// <summary>
        /// The boon, condition or effect that's referred to by the trait fact.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The trait fact description.
        /// If the trait fact doesn't have a description, this value is <see langword="null"/>.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The number of stacks applied.
        /// If the trait fact doesn't apply stacks, this value is <see langword="null"/>.
        /// </summary>
        public int? ApplyCount { get; set; }

        /// <summary>
        /// The duration of the effect in seconds.
        /// If the trait fact doesn't have a duration, this value is <see langword="null"/>.
        /// </summary>
        public int? Duration { get; set; }
    }
}
