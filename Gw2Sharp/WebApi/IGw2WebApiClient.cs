using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// An interface for the client implementation of the Guild Wars 2 web API.
    /// </summary>
    public interface IGw2WebApiClient
    {
        /// <summary>
        /// Gets the version 2 of the API.
        /// </summary>
        IGw2WebApiV2Client V2 { get; }
    }
}
