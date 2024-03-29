using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches endpoint.
    /// </summary>
    public interface IWvwMatchesClient :
        IBulkExpandableClient<WvwMatch, string>,
        IAllExpandableClient<WvwMatch>
    {
        /// <summary>
        /// Requests WvW match information with the specified world id.
        /// </summary>
        /// <param name="world">The world id.</param>
        /// <returns>The WvW matches with world endpoint client.</returns>
        IWvwMatchesWorldClient World(int world);

        /// <summary>
        /// Gets the WvW matches overview.
        /// </summary>
        IWvwMatchesOverviewClient Overview { get; }

        /// <summary>
        /// Gets the WvW matches scores.
        /// </summary>
        IWvwMatchesScoresClient Scores { get; }

        /// <summary>
        /// Gets the WvW matches stats.
        /// </summary>
        IWvwMatchesStatsClient Stats { get; }
    }
}
