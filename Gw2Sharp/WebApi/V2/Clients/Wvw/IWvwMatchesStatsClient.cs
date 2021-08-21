using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches stats endpoint.
    /// </summary>
    public interface IWvwMatchesStatsClient :
        IBulkExpandableClient<WvwMatchStats, string>,
        IAllExpandableClient<WvwMatchStats>
    {
        /// <summary>
        /// Requests WvW match stats information with the specified world id.
        /// </summary>
        /// <param name="world">The world id.</param>
        /// <returns>The WvW matches stats with world endpoint client.</returns>
        IWvwMatchesStatsWorldClient World(int world);
    }
}
