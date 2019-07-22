using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mounts endpoint.
    /// </summary>
    [EndpointPath("mounts")]
    public class MountsClient : BaseClient, IMountsClient
    {
        private readonly IMountsSkinsClient skins;
        private readonly IMountsTypesClient types;

        /// <summary>
        /// Creates a new <see cref="MountsClient"/> that is used for the API v2 mounts endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal MountsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.skins = new MountsSkinsClient(connection, gw2Client);
            this.types = new MountsTypesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IMountsSkinsClient Skins => this.skins;

        /// <inheritdoc />
        public virtual IMountsTypesClient Types => this.types;
    }
}
