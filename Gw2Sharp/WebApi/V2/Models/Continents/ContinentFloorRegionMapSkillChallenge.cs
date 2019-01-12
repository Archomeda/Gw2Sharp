namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map skill challenge.
    /// </summary>
    public class ContinentFloorRegionMapSkillChallenge : IIdentifiable<string>
    {
        /// <summary>
        /// The skill challenge id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The skill challenge coordinates.
        /// </summary>
        public Coordinates2 Coord { get; set; }
    }
}
