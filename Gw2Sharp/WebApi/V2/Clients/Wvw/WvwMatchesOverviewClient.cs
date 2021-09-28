using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW matches overview endpoint.
    /// </summary>
    [EndpointPath("wvw/matches/overview")]
    public class WvwMatchesOverviewClient : BaseEndpointBulkAllClient<WvwMatchOverview, string>, IWvwMatchesOverviewClient
    {
        /// <summary>
        /// Creates a new <see cref="WvwMatchesOverviewClient"/> that is used for the API v2 WvW matches overview endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal WvwMatchesOverviewClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public virtual IWvwMatchesOverviewWorldClient World(int world) =>
            new WvwMatchesOverviewWorldClient(this.Connection, this.Gw2Client!, world);
    }
}
