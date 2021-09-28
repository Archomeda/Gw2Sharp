using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches stats endpoint.
    /// </summary>
    [EndpointPath("wvw/matches/stats")]
    public class WvwMatchesStatsWorldClient : BaseEndpointBlobClient<WvwMatchStats>, IWvwMatchesStatsWorldClient
    {
        private readonly int world;

        /// <summary>
        /// Creates a new <see cref="WvwMatchesStatsWorldClient"/> that is used for the API v2 WvW matches stats with world endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="world">The world id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal WvwMatchesStatsWorldClient(IConnection connection, IGw2Client gw2Client, int world) :
            base(connection, gw2Client)
        {
            this.world = world;
        }

        /// <inheritdoc/>
        [EndpointQueryParameter("world")]
        public virtual int World => this.world;
    }
}
