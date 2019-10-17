namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A heal skill fact.
    /// </summary>
    public class SkillFactHeal : SkillFact
    {
        /// <summary>
        /// The amount of times the healing is applied.
        /// </summary>
        public int HitCount { get; set; }
    }
}
