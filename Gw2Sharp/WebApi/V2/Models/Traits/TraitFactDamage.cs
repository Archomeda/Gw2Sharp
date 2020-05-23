namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A damage trait fact.
    /// </summary>
    public class TraitFactDamage : TraitFact
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
