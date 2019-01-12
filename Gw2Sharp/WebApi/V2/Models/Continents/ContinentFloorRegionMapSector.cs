using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map sector.
    /// </summary>
    public class ContinentFloorRegionMapSector : IIdentifiable<int>
    {
        /// <summary>
        /// The sector id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The sector name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The sector level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The sector coordinates.
        /// </summary>
        public Coordinates2 Coord { get; set; }

        /// <summary>
        /// The sector bounds.
        /// </summary>
        public IReadOnlyList<Coordinates2> Bounds { get; set; } = new List<Coordinates2>();

        /// <summary>
        /// The sector chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;
    }
}
