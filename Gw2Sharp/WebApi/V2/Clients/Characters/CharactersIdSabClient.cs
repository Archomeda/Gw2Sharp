using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id sab endpoint.
    /// </summary>
    [EndpointPath("characters/:id/sab")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class CharactersIdSabClient : BaseCharactersSubBlobClient<CharactersSab>, ICharactersIdSabClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdSabClient"/> that is used for the API v2 characters id sab endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <see langword="null"/>.</exception>
        protected internal CharactersIdSabClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        { }
    }
}
