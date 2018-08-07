using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map task.
    /// </summary>
    public class ContinentFloorRegionMapTask : IIdentifiable<int>
    {
        /// <summary>
        /// The task id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The task objective.
        /// </summary>
        public string Objective { get; set; }

        /// <summary>
        /// The task level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The task coordinates.
        /// </summary>
        public Coordinates2 Coord { get; set; }

        /// <summary>
        /// The task bounds.
        /// </summary>
        public IReadOnlyList<Coordinates2> Bounds { get; set; }

        /// <summary>
        /// The sector chat link.
        /// </summary>
        public string ChatLink { get; set; }
    }
}
