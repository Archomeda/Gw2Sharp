using System;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// A client for the Guild Wars 2 web API.
    /// </summary>
    public class Gw2WebApiClient : IGw2WebApiClient, IWebApiClientInternal
    {
        /// <summary>
        /// The base URL for making Guild Wars 2 API requests.
        /// </summary>
        internal static Uri UrlBase => new Uri("https://api.guildwars2.com");

        private readonly IGw2WebApiV2Client v2;

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
            this.v2 = new Gw2WebApiV2Client(connection);
        }

        /// <inheritdoc />
        IConnection IWebApiClientInternal.Connection => this.Connection;

        /// <summary>
        /// Provides the client connection to make web requests.
        /// </summary>
        internal IConnection Connection { get; }

        /// <inheritdoc />
        public virtual IGw2WebApiV2Client V2 => this.v2;
    }
}
