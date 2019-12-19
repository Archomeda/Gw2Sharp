using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id specializations endpoint.
    /// </summary>
    [EndpointPath("characters/:id/specializations")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
    public class CharactersIdSpecializationsClient : BaseCharactersSubBlobClient<CharactersSpecializations>, ICharactersIdSpecializationsClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdSpecializationsClient"/> that is used for the API v2 characters id specializations endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        protected internal CharactersIdSpecializationsClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        { }
    }
}
