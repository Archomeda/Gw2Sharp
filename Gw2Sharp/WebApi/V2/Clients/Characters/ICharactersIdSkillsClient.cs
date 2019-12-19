using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id skills endpoint.
    /// </summary>
    [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
    public interface ICharactersIdSkillsClient :
        IAuthenticatedClient,
        IBlobClient<CharactersSkills>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
