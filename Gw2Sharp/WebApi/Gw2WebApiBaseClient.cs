using System;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// An abstract base class for implementing web API clients.
    /// </summary>
    public abstract class Gw2WebApiBaseClient
    {
        /// <summary>
        /// Creates a new base client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected Gw2WebApiBaseClient(IConnection connection, IGw2Client gw2Client)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.Gw2Client = gw2Client ?? throw new ArgumentNullException(nameof(gw2Client));
        }

        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        internal IConnection Connection { get; }

        /// <summary>
        /// Gets the Guild Wars 2 client.
        /// </summary>
        internal IGw2Client Gw2Client { get; }
    }
}
