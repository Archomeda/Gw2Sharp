using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps endpoint.
    /// </summary>
    public interface IContinentsFloorsRegionsMapsClient :
        IAllExpandableClient<ContinentFloorRegionMap>,
        IBulkExpandableClient<ContinentFloorRegionMap, int>,
        ILocalizedClient,
        IPaginatedClient<ContinentFloorRegionMap>
    {
        /// <summary>
        /// The continent id.
        /// </summary>
        int ContinentId { get; }

        /// <summary>
        /// The floor id.
        /// </summary>
        int FloorId { get; }

        /// <summary>
        /// The region id.
        /// </summary>
        int RegionId { get; }

        /// <summary>
        /// Gets a continent floor region map by id.
        /// </summary>
        IContinentsFloorsRegionsMapsIdClient this[int mapId] { get; }
    }
}
