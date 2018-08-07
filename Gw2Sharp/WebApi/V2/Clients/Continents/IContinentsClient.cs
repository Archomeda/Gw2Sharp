
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents endpoint.
    /// </summary>
    public interface IContinentsClient:
        IAllExpandableClient<Continent>,
        IBulkExpandableClient<Continent, int>,
        ILocalizedClient<Continent>,
        IPaginatedClient<Continent>
    {
        /// <summary>
        /// Gets a continent by id.
        /// </summary>
        IContinentsIdClient this[int continentId] { get; }
    }
}
