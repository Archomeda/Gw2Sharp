using System;
using Gw2Sharp.WebApi.Render;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// A client for the Guild Wars 2 web API.
    /// </summary>
    public class Gw2WebApiClient : BaseClient, IGw2WebApiClient
    {
        /// <summary>
        /// The base URL for making Guild Wars 2 API requests.
        /// </summary>
        internal static Uri UrlBase => new Uri("https://api.guildwars2.com");

        private readonly IGw2WebApiRenderClient render;
        private readonly IGw2WebApiV2Client v2;

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiClient"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal Gw2WebApiClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (gw2Client == null)
                throw new ArgumentNullException(nameof(gw2Client));

            this.render = new Gw2WebApiRenderClient(connection, gw2Client);
            this.v2 = new Gw2WebApiV2Client(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IGw2WebApiRenderClient Render => this.render;

        /// <inheritdoc />
        public virtual IGw2WebApiV2Client V2 => this.v2;
    }
}
