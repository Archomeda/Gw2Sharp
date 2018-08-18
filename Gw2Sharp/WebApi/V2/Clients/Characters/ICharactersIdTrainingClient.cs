using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id training endpoint.
    /// </summary>
    public interface ICharactersIdTrainingClient :
        IAuthenticatedClient<CharactersTraining>,
        IBlobClient<CharactersTraining>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
