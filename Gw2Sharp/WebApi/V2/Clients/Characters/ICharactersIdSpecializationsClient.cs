using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id specializations endpoint.
    /// </summary>
    public interface ICharactersIdSpecializationsClient :
        IAuthenticatedClient,
        IBlobClient<CharactersSpecializations>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
