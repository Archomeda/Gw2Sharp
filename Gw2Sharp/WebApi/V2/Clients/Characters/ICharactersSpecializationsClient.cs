using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters specializations endpoint.
    /// </summary>
    public interface ICharactersSpecializationsClient :
        IAuthenticatedClient<CharactersSpecializations>,
        IBlobClient<CharactersSpecializations>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
