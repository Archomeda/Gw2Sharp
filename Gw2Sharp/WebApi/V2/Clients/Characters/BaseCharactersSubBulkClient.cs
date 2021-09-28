using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing character subendpoint bulk clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    /// <typeparam name="TId">The id value type.</typeparam>
    [EndpointPathSegment("id", 0)]
    public abstract class BaseCharactersSubBulkClient<TObject, TId> : BaseEndpointBulkAllClient<TObject, TId>
        where TObject : IApiV2Object, IIdentifiable<TId>
        where TId : notnull
    {
        /// <summary>
        /// Creates a new base character subendpoint bulk client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="characterName">The character name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <see langword="null"/>.</exception>
        protected BaseCharactersSubBulkClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        {
            this.CharacterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
        }

        /// <summary>
        /// The character name.
        /// </summary>
        public virtual string CharacterName { get; protected set; }
    }
}
