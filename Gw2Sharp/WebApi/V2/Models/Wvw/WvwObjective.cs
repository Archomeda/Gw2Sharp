using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw objective.
    /// </summary>
    public class WvwObjective : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The objective id
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The objective name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The objective type
        /// </summary>
        public ApiEnum<WvwObjectiveType> Type { get; set; } = new ApiEnum<WvwObjectiveType>();

        /// <summary>
        /// The sector the objective can be found in
        /// For more information, see <see cref="IGw2WebApiV2Client.Continents"/>.
        /// </summary>
        public int SectorId { get; set; }

        /// <summary>
        /// The map the objective can be found in
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Maps"/>.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// The map type of the map the objective can be found in
        /// </summary>
        public ApiEnum<WvwMapType> MapType { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// The array of coordinates of this objective's marker on the map.
        /// Representing X, Y and Z
        /// </summary>
        public IReadOnlyList<double> Coord { get; set; } = Array.Empty<double>();

        /// <summary>
        /// The array of coordinates of this objective's label on the map.
        /// Representing X, Y and Z
        /// </summary>
        public IReadOnlyList<double> LabelCoord { get; set; } = Array.Empty<double>();

        /// <summary>
        /// The render url of the marker icon
        /// </summary>
        public string Marker { get; set; } = string.Empty;

        /// <summary>
        /// The chat link representing the objective on the world map
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The upgrade id of the objective
        /// </summary>
        public int UpgradeId { get; set; }

    }
}
