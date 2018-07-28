namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home endpoint.
    /// </summary>
    [EndpointPath("account/home")]
    public class AccountHomeClient : BaseClient, IAccountHomeClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountHomeClient"/> that is used for the API v2 account home endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountHomeClient(IConnection connection) : base(connection)
        {
            this.Cats = new AccountHomeCatsClient(connection);
            this.Nodes = new AccountHomeNodesClient(connection);
        }

        /// <inheritdoc />
        public virtual IAccountHomeCatsClient Cats { get; protected set; }

        /// <inheritdoc />
        public virtual IAccountHomeNodesClient Nodes { get; protected set; }
    }
}
