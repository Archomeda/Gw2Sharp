using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches scores endpoint.
    /// </summary>
    public interface IWvwMatchesScoresClient :
        IBulkExpandableClient<WvwMatchScores, string>,
        IAllExpandableClient<WvwMatchScores>
    {
        /// <summary>
        /// Requests WvW match scores information with the specified world id.
        /// </summary>
        /// <param name="world">The world id.</param>
        /// <returns>The WvW matches scores with world endpoint client.</returns>
        IWvwMatchesScoresWorldClient World(int world);
    }
}
