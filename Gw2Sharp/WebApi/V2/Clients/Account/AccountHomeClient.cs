using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home endpoint.
    /// </summary>
    [EndpointPath("account/home")]
    public class AccountHomeClient : BaseClient, IAccountHomeClient
    {
        private readonly IAccountHomeCatsClient cats;
        private readonly IAccountHomeNodesClient nodes;

        /// <summary>
        /// Creates a new <see cref="AccountHomeClient"/> that is used for the API v2 account home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountHomeClient(IConnection connection) :
            base(connection)
        {
            this.cats = new AccountHomeCatsClient(connection);
            this.nodes = new AccountHomeNodesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountHomeCatsClient Cats => this.cats;

        /// <inheritdoc />
        public virtual IAccountHomeNodesClient Nodes => this.nodes;
    }
}
