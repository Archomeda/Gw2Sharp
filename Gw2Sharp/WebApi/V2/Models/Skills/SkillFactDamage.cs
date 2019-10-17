namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A damage skill fact.
    /// </summary>
    public class SkillFactDamage : SkillFact
    {
        /// <summary>
        /// The amount of times the damage hits.
        /// </summary>
        public int HitCount { get; set; }

        /// <summary>
        /// The damage multiplier.
        /// </summary>
        public double DmgMultiplier { get; set; }
    }
}
