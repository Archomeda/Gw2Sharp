using Gw2Sharp.WebApi;

namespace Gw2Sharp
{
    /// <summary>
    /// An interface for the client implementation of Guild Wars 2 APIs.
    /// </summary>
    public interface IGw2Client
    {
        /// <summary>
        /// Gets the web API.
        /// </summary>
        IGw2WebApiClient WebApi { get; }
    }
}
