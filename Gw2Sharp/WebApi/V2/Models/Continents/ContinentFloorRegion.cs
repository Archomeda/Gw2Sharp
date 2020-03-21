using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region.
    /// </summary>
    public class ContinentFloorRegion : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The region id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The region name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The region label coordinates.
        /// </summary>
        public Coordinates2 LabelCoord { get; set; }

        /// <summary>
        /// The region continent rectangle.
        /// </summary>
        [JsonConverter(typeof(TopDownRectangleConverter))]
        public Rectangle ContinentRect { get; set; }

        /// <summary>
        /// The region maps.
        /// </summary>
        public IReadOnlyDictionary<int, ContinentFloorRegionMap> Maps { get; set; } = new Dictionary<int, ContinentFloorRegionMap>();
    }
}
