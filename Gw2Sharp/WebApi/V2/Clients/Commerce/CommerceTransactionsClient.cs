using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions")]
    public class CommerceTransactionsClient : Gw2WebApiBaseClient, ICommerceTransactionsClient
    {
        private readonly ICommerceTransactionsCurrentClient current;
        private readonly ICommerceTransactionsHistoryClient history;

        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsClient"/> that is used for the API v2 commerce transactions endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal CommerceTransactionsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.current = new CommerceTransactionsCurrentClient(connection, gw2Client);
            this.history = new CommerceTransactionsHistoryClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentClient Current => this.current;

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistoryClient History => this.history;
    }
}
