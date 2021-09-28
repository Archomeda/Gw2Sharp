using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing guild subendpoint clients.
    /// </summary>
    [EndpointPathSegment("id", 0)]
    public abstract class BaseGuildSubClient<TObject> : BaseEndpointBlobClient<TObject>
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Creates a new base guild subendpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="guildId">The guild id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected BaseGuildSubClient(IConnection connection, IGw2Client gw2Client, Guid guildId) :
            base(connection, gw2Client, guildId.ToString())
        {
            this.GuildId = guildId;
        }

        /// <summary>
        /// The guild id.
        /// </summary>
        public virtual Guid GuildId { get; protected set; }
    }
}
