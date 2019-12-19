using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters endpoint.
    /// </summary>
    [EndpointPath("characters")]
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class CharactersClient : BaseEndpointBulkAllClient<Character, string>, ICharactersClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersClient"/> that is used for the API v2 characters endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal CharactersClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public virtual ICharactersIdClient this[string characterName] => new CharactersIdClient(this.Connection, this.Gw2Client!, characterName);
    }
}
