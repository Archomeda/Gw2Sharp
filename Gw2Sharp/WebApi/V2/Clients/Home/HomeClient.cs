using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home endpoint.
    /// </summary>
    [EndpointPath("home")]
    public class HomeClient : Gw2WebApiBaseClient, IHomeClient
    {
        private readonly IHomeCatsClient cats;
        private readonly IHomeNodesClient nodes;

        /// <summary>
        /// Creates a new <see cref="HomeClient"/> that is used for the API v2 home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal HomeClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.cats = new HomeCatsClient(connection, gw2Client);
            this.nodes = new HomeNodesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IHomeCatsClient Cats => this.cats;

        /// <inheritdoc />
        public virtual IHomeNodesClient Nodes => this.nodes;
    }
}
