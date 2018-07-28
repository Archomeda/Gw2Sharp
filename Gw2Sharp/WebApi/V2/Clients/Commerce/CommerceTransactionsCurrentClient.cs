namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/current")]
    public class CommerceTransactionsCurrentClient : BaseClient, ICommerceTransactionsCurrentClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsCurrentClient"/> that is used for the API v2 commerce transactions current endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CommerceTransactionsCurrentClient(IConnection connection) : base(connection)
        {
            this.Buys = new CommerceTransactionsCurrentBuysClient(connection);
            this.Sells = new CommerceTransactionsCurrentSellsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentBuysClient Buys { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentSellsClient Sells { get; protected set; }
    }
}
