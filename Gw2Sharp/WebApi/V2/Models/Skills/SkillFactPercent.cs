namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A percent skill fact.
    /// </summary>
    public class SkillFactPercent : SkillFact
    {
        /// <summary>
        /// The skill fact percentage.
        /// </summary>
        public double Percent { get; set; }

        /// <summary>
        /// The skill fact value.
        /// If the skill fact doesn't have a value, this value is <c>null</c>.
        /// </summary>
        public double? Value { get; set; }
    }
}
