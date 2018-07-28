using Gw2Sharp.WebApi.V2;
using System;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// A client for the Guild Wars 2 web API.
    /// </summary>
    public class Gw2WebApiClient : IGw2WebApiClient
    {
        /// <summary>
        /// The base URL for making Guild Wars 2 API requests.
        /// </summary>
        public static readonly Uri UrlBase = new Uri("https://api.guildwars2.com");

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiClient"/>.
        /// </summary>
        public Gw2WebApiClient() : this(new Connection()) { }

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiClient"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public Gw2WebApiClient(IConnection connection)
        {
            this.Connection = connection;
            this.V2 = new Gw2WebApiV2Client(connection);
        }

        /// <inheritdoc />
        public IConnection Connection { get; private set; }

        /// <inheritdoc />
        public virtual IGw2WebApiV2Client V2 { get; protected set; }
    }
}
