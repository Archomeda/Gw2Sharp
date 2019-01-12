using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing clients.
    /// </summary>
    public abstract class BaseClient : IClient
    {
        /// <summary>
        /// Creates a new base client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public BaseClient(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <inheritdoc />
        public IConnection Connection { get; private set; }
    }
}
