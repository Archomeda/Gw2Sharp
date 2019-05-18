using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem endpoint.
    /// </summary>
    [EndpointPath("emblem")]
    public class EmblemClient : BaseClient, IEmblemClient
    {
        /// <summary>
        /// Creates a new <see cref="EmblemClient"/> that is used for the API v2 emblem endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public EmblemClient(IConnection connection) :
            base(connection)
        {
            this.Backgrounds = new EmblemBackgroundsClient(connection);
            this.Foregrounds = new EmblemForegroundsClient(connection);
        }

        /// <inheritdoc />
        public virtual IEmblemBackgroundsClient Backgrounds { get; protected set; }

        /// <inheritdoc />
        public virtual IEmblemForegroundsClient Foregrounds { get; protected set; }
    }
}
