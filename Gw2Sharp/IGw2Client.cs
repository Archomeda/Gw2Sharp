using System;
using System.Runtime.Versioning;
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
        /// <exception cref="PlatformNotSupportedException">Mumble Link is not available on non-Windows platforms.</exception>
#if NET5_0_OR_GREATER
        [SupportedOSPlatform("windows")]
#endif
        IGw2MumbleClient Mumble { get; }

        /// <summary>
        /// Gets the web API.
        /// </summary>
        IGw2WebApiClient WebApi { get; }
    }
}
