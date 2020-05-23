namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A attribute adjusting trait fact.
    /// </summary>
    public class TraitFactAttributeAdjust : TraitFact
    {
        /// <summary>
        /// The amount that <see cref="Target"/> adjusts, based on a level 80 character at base stats.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The attribute that this skill fact adjusts.
        /// </summary>
        public ApiEnum<AttributeType> Target { get; set; } = string.Empty;
    }
}
