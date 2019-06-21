using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing clients.
    /// </summary>
    public abstract class BaseClient : IClient, IWebApiClientInternal
    {
        /// <summary>
        /// Creates a new base client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected BaseClient(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <inheritdoc />
        IConnection IWebApiClientInternal.Connection => this.Connection;

        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        internal IConnection Connection { get; }
    }
}
