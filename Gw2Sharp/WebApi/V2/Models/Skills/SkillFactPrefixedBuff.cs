namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A prefixed buff skill fact.
    /// </summary>
    public class SkillFactPrefixedBuff : SkillFact
    {
        /// <summary>
        /// The boon, condition or effect that's referred to by the skill fact.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The skill fact description.
        /// If the skill fact doesn't have a description, this value is <c>null</c>.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The number of stacks applied.
        /// If the skill fact doesn't apply stacks, this value is <c>null</c>.
        /// </summary>
        public int? ApplyCount { get; set; }

        /// <summary>
        /// The duration of the effect in seconds.
        /// If the skill fact doesn't have a duration, this value is <c>null</c>.
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// The prefix that describes the icon shown before the fact.
        /// </summary>
        public SkillFactBuffPrefix Prefix { get; set; } = new SkillFactBuffPrefix();
    }
}
