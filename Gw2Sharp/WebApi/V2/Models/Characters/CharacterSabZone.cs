namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character Super Adventure Box zone.
    /// </summary>
    public class CharacterSabZone : IIdentifiable<int>
    {
        /// <summary>
        /// The zone id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The zone mode.
        /// </summary>
        public string Mode { get; set; } = string.Empty;

        /// <summary>
        /// The zone's world number.
        /// </summary>
        public int World { get; set; }

        /// <summary>
        /// The zone's world zone number.
        /// </summary>
        public int Zone { get; set; }
    }
}
