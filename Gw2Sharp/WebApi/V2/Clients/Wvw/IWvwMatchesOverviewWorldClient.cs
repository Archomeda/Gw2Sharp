using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches overview with world endpoint.
    /// </summary>
    public interface IWvwMatchesOverviewWorldClient :
        IBlobClient<WvwMatchOverview>
    {
        /// <summary>
        /// The world id.
        /// </summary>
        int World { get; }
    }
}
