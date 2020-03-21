using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.Models;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a map.
    /// </summary>
    public class Map : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The map id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The map name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

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
        public ApiEnum<MapType> Type { get; set; } = new ApiEnum<MapType>();

        /// <summary>
        /// The available map floors.
        /// </summary>
        public IReadOnlyList<int> Floors { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The region id.
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// The region name.
        /// </summary>
        public string RegionName { get; set; } = string.Empty;

        /// <summary>
        /// The continent id.
        /// </summary>
        public int ContinentId { get; set; }

        /// <summary>
        /// The continent name.
        /// </summary>
        public string ContinentName { get; set; } = string.Empty;

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
    }
}
