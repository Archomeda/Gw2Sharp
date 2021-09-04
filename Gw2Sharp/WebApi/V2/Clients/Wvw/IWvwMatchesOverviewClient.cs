using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches overview endpoint.
    /// </summary>
    public interface IWvwMatchesOverviewClient :
        IBulkExpandableClient<WvwMatchOverview, string>,
        IAllExpandableClient<WvwMatchOverview>
    {
        /// <summary>
        /// Requests WvW match overview information with the specified world id.
        /// </summary>
        /// <param name="world">The world id.</param>
        /// <returns>The WvW matches overview with world endpoint client.</returns>
        IWvwMatchesOverviewWorldClient World(int world);
    }
}
