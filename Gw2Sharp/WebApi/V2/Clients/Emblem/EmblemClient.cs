using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem endpoint.
    /// </summary>
    [EndpointPath("emblem")]
    public class EmblemClient : Gw2WebApiBaseClient, IEmblemClient
    {
        private readonly IEmblemBackgroundsClient backgrounds;
        private readonly IEmblemForegroundsClient foregrounds;

        /// <summary>
        /// Creates a new <see cref="EmblemClient"/> that is used for the API v2 emblem endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal EmblemClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.backgrounds = new EmblemBackgroundsClient(connection, gw2Client);
            this.foregrounds = new EmblemForegroundsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IEmblemBackgroundsClient Backgrounds => this.backgrounds;

        /// <inheritdoc />
        public virtual IEmblemForegroundsClient Foregrounds => this.foregrounds;
    }
}
