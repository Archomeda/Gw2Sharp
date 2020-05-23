using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors endpoint.
    /// </summary>
    public interface IContinentsFloorsClient :
        IAllExpandableClient<ContinentFloor>,
        IBulkExpandableClient<ContinentFloor, int>,
        ILocalizedClient,
        IPaginatedClient<ContinentFloor>
    {
        /// <summary>
        /// The continent id.
        /// </summary>
        int ContinentId { get; }

        /// <summary>
        /// Gets a continent floor by id.
        /// </summary>
        IContinentsFloorsIdClient this[int floorId] { get; }
    }
}
