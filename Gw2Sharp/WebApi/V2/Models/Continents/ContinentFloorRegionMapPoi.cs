namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a continent floor region map point of interest.
    /// </summary>
    public class ContinentFloorRegionMapPoi : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The point of interest id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The point of interest name.
        /// If it has no name, this value is <c>null</c>.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The floor this point of interest is on.
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// The point of interest coordinates.
        /// </summary>
        public Coordinates2 Coord { get; set; }

        /// <summary>
        /// The point of interest type.
        /// </summary>
        public ApiEnum<PoiType> Type { get; set; } = new ApiEnum<PoiType>();

        /// <summary>
        /// The point of interest chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The point of interest icon.
        /// If the point of interest has no icon, this value is <c>null</c>.
        /// </summary>
        public string? Icon { get; set; }
    }
}
