using System;
using Gw2Sharp.Mumble;
using Gw2Sharp.WebApi;

namespace Gw2Sharp
{
    /// <summary>
    /// An interface for the client implementation of Guild Wars 2 APIs.
    /// </summary>
    public interface IGw2Client : IDisposable
    {
        /// <summary>
        /// Gets the Mumble Link client API.
        /// </summary>
        IGw2MumbleClient Mumble { get; }

        /// <summary>
        /// Gets the web API.
        /// </summary>
        IGw2WebApiClient WebApi { get; }
    }
}
