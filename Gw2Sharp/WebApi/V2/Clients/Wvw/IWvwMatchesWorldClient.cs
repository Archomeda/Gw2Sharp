using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches with world endpoint.
    /// </summary>
    public interface IWvwMatchesWorldClient :
        IBlobClient<WvwMatch>
    {
        /// <summary>
        /// The world id.
        /// </summary>
        int World { get; }
    }
}
