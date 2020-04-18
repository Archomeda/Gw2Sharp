using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps sectors endpoint.
    /// </summary>
    public interface IContinentsFloorsRegionsMapsSectorsClient :
        IAllExpandableClient<ContinentFloorRegionMapSector>,
        IBulkExpandableClient<ContinentFloorRegionMapSector, int>,
        ILocalizedClient,
        IPaginatedClient<ContinentFloorRegionMapSector>
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
        /// The map id.
        /// </summary>
        int MapId { get; }
    }
}
