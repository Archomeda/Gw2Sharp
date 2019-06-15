using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home endpoint.
    /// </summary>
    [EndpointPath("home")]
    public class HomeClient : BaseClient, IHomeClient
    {
        /// <summary>
        /// Creates a new <see cref="HomeClient"/> that is used for the API v2 home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public HomeClient(IConnection connection) :
            base(connection)
        {
            this.Cats = new HomeCatsClient(connection);
            this.Nodes = new HomeNodesClient(connection);
        }

        /// <inheritdoc />
        public virtual IHomeCatsClient Cats { get; protected set; }

        /// <inheritdoc />
        public virtual IHomeNodesClient Nodes { get; protected set; }
    }
}
