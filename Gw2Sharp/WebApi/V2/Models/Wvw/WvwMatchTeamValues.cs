namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents team values of a WvW match.
    /// </summary>
    public class WvwMatchTeamValues : ApiV2BaseObject
    {
        /// <summary>
        /// The red team value.
        /// </summary>
        public int Red { get; set; }

        /// <summary>
        /// The blue team value.
        /// </summary>
        public int Blue { get; set; }

        /// <summary>
        /// The green team value.
        /// </summary>
        public int Green { get; set; }
    }
}
