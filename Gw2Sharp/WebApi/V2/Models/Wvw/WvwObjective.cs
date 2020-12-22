using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW objective.
    /// </summary>
    public class WvwObjective : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The objective id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The objective name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The objective type.
        /// </summary>
        public ApiEnum<WvwObjectiveType> Type { get; set; } = new ApiEnum<WvwObjectiveType>();

        /// <summary>
        /// The sector the objective can be found in.
        /// For more information, see <see cref="IGw2WebApiV2Client.Continents"/>.
        /// </summary>
        public int SectorId { get; set; }

        /// <summary>
        /// The map the objective can be found in.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Maps"/>.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// The map type.
        /// </summary>
        public ApiEnum<WvwMapType> MapType { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// The objective marker coordinates.
        /// </summary>
        public Coordinates3 Coord { get; set; }

        /// <summary>
        /// The objective label coordinates.
        /// </summary>
        public Coordinates2 LabelCoord { get; set; }

        /// <summary>
        /// The marker icon URL.
        /// </summary>
        public RenderUrl Marker { get; set; }

        /// <summary>
        /// The chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The objective upgrade id.
        /// Can be resolved against <see cref="IWvwClient.Upgrades"/>.
        /// </summary>
        public int UpgradeId { get; set; }
    }
}
