namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A healing adjusting skill fact.
    /// </summary>
    public class SkillFactHealingAdjust : SkillFact
    {
        /// <summary>
        /// The amount of times the healing adjustment is applied.
        /// </summary>
        public int HitCount { get; set; }
    }
}
