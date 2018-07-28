using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters endpoint.
    /// </summary>
    [EndpointPath("characters")]
    public class CharactersClient : BaseEndpointBulkAllClient<Character, string>, ICharactersClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersClient"/> that is used for the API v2 characters endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CharactersClient(IConnection connection) : base(connection) { }

        /// <inheritdoc />
        public virtual ICharactersIdClient this[string characterName] => new CharactersIdClient(this.Connection, characterName);
    }
}
