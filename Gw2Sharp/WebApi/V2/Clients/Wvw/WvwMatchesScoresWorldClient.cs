using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches scores endpoint.
    /// </summary>
    [EndpointPath("wvw/matches/scores")]
    public class WvwMatchesScoresWorldClient : BaseEndpointBlobClient<WvwMatchScores>, IWvwMatchesScoresWorldClient
    {
        private readonly int world;

        /// <summary>
        /// Creates a new <see cref="WvwMatchesScoresWorldClient"/> that is used for the API v2 WvW matches scores with world endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="world">The world id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal WvwMatchesScoresWorldClient(IConnection connection, IGw2Client gw2Client, int world) :
            base(connection, gw2Client)
        {
            this.world = world;
        }

        /// <inheritdoc/>
        [EndpointQueryParameter("world")]
        public virtual int World => this.world;
    }
}
