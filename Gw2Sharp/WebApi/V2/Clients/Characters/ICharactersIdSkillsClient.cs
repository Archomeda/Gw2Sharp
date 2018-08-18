using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id skills endpoint.
    /// </summary>
    public interface ICharactersIdSkillsClient :
        IAuthenticatedClient<CharactersSkills>,
        IBlobClient<CharactersSkills>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
