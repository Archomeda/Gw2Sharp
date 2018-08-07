using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent.
    /// </summary>
    public class Continent : IIdentifiable<int>
    {
        /// <summary>
        /// The continent id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The continent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The continent dimensions.
        /// </summary>
        public Coordinates2 ContinentDims { get; set; }

        /// <summary>
        /// The minimum zoom level.
        /// </summary>
        public int MinZoom { get; set; }

        /// <summary>
        /// The maximum zoom level.
        /// </summary>
        public int MaxZoom { get; set; }

        /// <summary>
        /// The continent floors.
        /// Each element can be resolved against <see cref="IContinentsIdClient.Floors"/>.
        /// </summary>
        public IReadOnlyList<int> Floors { get; set; }
    }
}
