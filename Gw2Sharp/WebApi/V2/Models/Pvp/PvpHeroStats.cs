namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP hero stats.
    /// </summary>
    public class PvpHeroStats
    {
        /// <summary>
        /// The hero offense stat.
        /// </summary>
        public int Offense { get; set; }

        /// <summary>
        /// The hero defense stat.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// The hero speed stat.
        /// </summary>
        public int Speed { get; set; }
    }
}
