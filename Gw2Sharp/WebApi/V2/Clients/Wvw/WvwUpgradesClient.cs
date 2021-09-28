using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW upgrades endpoint.
    /// </summary>
    [EndpointPath("wvw/upgrades")]
    public class WvwUpgradesClient : BaseEndpointBulkAllClient<WvwUpgrade, int>, IWvwUpgradesClient
    {
        /// <summary>
        /// Creates a new <see cref="WvwUpgradesClient"/> that is used for the API v2 WvW upgrades endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal WvwUpgradesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
