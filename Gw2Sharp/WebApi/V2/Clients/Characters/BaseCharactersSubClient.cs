using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing character subendpoint clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    [EndpointPathSegment("id", 0)]
    public abstract class BaseCharactersSubClient<TObject> : BaseEndpointBlobClient<TObject>
    {
        /// <summary>
        /// Creates a new base character subendpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public BaseCharactersSubClient(IConnection connection, string characterName) : base(connection, characterName)
        {
            this.CharacterName = characterName ?? throw new ArgumentNullException(nameof(characterName));
        }

        /// <summary>
        /// The character name.
        /// </summary>
        public virtual string CharacterName { get; protected set; }
    }
}
