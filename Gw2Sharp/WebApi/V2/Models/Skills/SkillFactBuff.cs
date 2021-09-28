namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A buff skill fact.
    /// </summary>
    public class SkillFactBuff : SkillFact
    {
        /// <summary>
        /// The boon, condition or effect that's referred to by the skill fact.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The skill fact description.
        /// If the skill fact doesn't have a description, this value is <see langword="null"/>.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The number of stacks applied.
        /// If the skill fact doesn't apply stacks, this value is <see langword="null"/>.
        /// </summary>
        public int? ApplyCount { get; set; }

        /// <summary>
        /// The duration of the effect in seconds.
        /// If the skill fact doesn't have a duration, this value is <see langword="null"/>.
        /// </summary>
        public int? Duration { get; set; }
    }
}
