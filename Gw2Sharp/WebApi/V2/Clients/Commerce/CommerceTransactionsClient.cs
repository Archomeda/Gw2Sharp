using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions")]
    public class CommerceTransactionsClient : BaseClient, ICommerceTransactionsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsClient"/> that is used for the API v2 commerce transactions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceTransactionsClient(IConnection connection) :
            base(connection)
        {
            this.Current = new CommerceTransactionsCurrentClient(connection);
            this.History = new CommerceTransactionsHistoryClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentClient Current { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistoryClient History { get; protected set; }
    }
}
