using System;
using Gw2Sharp.WebApi.V2;

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
        /// <exception cref="NullReferenceException"><paramref name="connection"/> is <c>null</c>.</exception>
        public Gw2WebApiClient(IConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            this.v2 = new Gw2WebApiV2Client(connection);
        }

        /// <inheritdoc />
        public virtual IGw2WebApiV2Client V2 => this.v2;
    }
}
