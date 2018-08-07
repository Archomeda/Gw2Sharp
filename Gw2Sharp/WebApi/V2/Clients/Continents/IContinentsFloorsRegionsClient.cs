using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions endpoint.
    /// </summary>
    public interface IContinentsFloorsRegionsClient :
        IAllExpandableClient<ContinentFloorRegion>,
        IBulkExpandableClient<ContinentFloorRegion, int>,
        ILocalizedClient<ContinentFloorRegion>,
        IPaginatedClient<ContinentFloorRegion>
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
        /// Gets a continent floor region by id.
        /// </summary>
        IContinentsFloorsRegionsIdClient this[int regionId] { get; }
    }
}
