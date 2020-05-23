namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A buff conversion trait fact.
    /// </summary>
    public class TraitFactBuffConversion : TraitFact
    {
        /// <summary>
        /// The boon, condition or effect that's referred to by the trait fact as source.
        /// </summary>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// The boon, condition or effect that's referred to by the trait fact as target.
        /// </summary>
        public string Target { get; set; } = string.Empty;

        /// <summary>
        /// The trait fact percentage.
        /// </summary>
        public double Percent { get; set; }
    }
}
