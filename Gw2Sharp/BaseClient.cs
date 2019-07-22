using System;

namespace Gw2Sharp
{
    /// <summary>
    /// An abstract base class for implementing clients.
    /// </summary>
    public abstract class BaseClient : IClient, IClientInternal
    {
        /// <summary>
        /// Creates a new base client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected BaseClient(IConnection connection, IGw2Client? gw2Client)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.Gw2Client = gw2Client;
        }

        /// <inheritdoc />
        IConnection IClientInternal.Connection => this.Connection;

        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        internal IConnection Connection { get; }

        /// <inheritdoc />
        IGw2Client? IClientInternal.Gw2Client => this.Gw2Client;

        /// <summary>
        /// Gets the Guild Wars 2 client.
        /// </summary>
        internal IGw2Client? Gw2Client { get; set; }
    }
}
