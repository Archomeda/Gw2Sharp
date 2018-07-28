using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a map.
    /// </summary>
    public class Map : IIdentifiable<int>
    {
        /// <summary>
        /// The map name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The minimum level.
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// The maximum level.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// The default floor.
        /// </summary>
        public int DefaultFloor { get; set; }

        /// <summary>
        /// The map type.
        /// </summary>
        public ApiEnum<MapType> Type { get; set; }

        /// <summary>
        /// The available map floors.
        /// </summary>
        public IReadOnlyList<int> Floors { get; set; }

        /// <summary>
        /// The region id.
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// The region name.
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// The continent id.
        /// </summary>
        public int ContinentId { get; set; }

        /// <summary>
        /// The continent name.
        /// </summary>
        public string ContinentName { get; set; }

        /// <summary>
        /// The map rectangle.
        /// </summary>
        [JsonConverter(typeof(BottomUpRectangleConverter))]
        public Rectangle MapRect { get; set; }

        /// <summary>
        /// The continent rectangle.
        /// </summary>
        [JsonConverter(typeof(TopDownRectangleConverter))]
        public Rectangle ContinentRect { get; set; }

        /// <summary>
        /// The map id.
        /// </summary>
        public int Id { get; set; }
    }
}
