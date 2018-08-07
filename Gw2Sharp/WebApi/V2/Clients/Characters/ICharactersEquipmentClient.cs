using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters equipment endpoint.
    /// </summary>
    public interface ICharactersEquipmentClient :
        IAuthenticatedClient<CharactersEquipment>,
        IBlobClient<CharactersEquipment>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
