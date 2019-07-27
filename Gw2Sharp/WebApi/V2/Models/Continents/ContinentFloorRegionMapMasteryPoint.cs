using Gw2Sharp.Models;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map mastery point.
    /// </summary>
    public class ContinentFloorRegionMapMasteryPoint : IIdentifiable<int>
    {
        /// <summary>
        /// The mastery point id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mastery point coordinates.
        /// </summary>
        public Coordinates2 Coord { get; set; }

        /// <summary>
        /// The mastery point region.
        /// </summary>
        public string Region { get; set; } = string.Empty;
    }
}
