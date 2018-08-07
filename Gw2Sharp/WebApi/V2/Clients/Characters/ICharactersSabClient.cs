using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters sab endpoint.
    /// </summary>
    public interface ICharactersSabClient :
        IAuthenticatedClient<CharactersSab>,
        IBlobClient<CharactersSab>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
