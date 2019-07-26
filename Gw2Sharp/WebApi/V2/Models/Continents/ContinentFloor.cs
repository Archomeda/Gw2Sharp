using System.Collections.Generic;
using Gw2Sharp.Json.Converters;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor.
    /// </summary>
    public class ContinentFloor : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The floor id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The floor texture dimensions.
        /// </summary>
        public Coordinates2 TextureDims { get; set; }

        /// <summary>
        /// The floor map rectangle that represent valid floor coordinates.
        /// </summary>
        [JsonConverter(typeof(TopDownRectangleConverter))]
        public Rectangle ClampedView { get; set; }

        /// <summary>
        /// The floor regions.
        /// </summary>
        public IReadOnlyDictionary<int, ContinentFloorRegion> Regions { get; set; } = new Dictionary<int, ContinentFloorRegion>();
    }
}
