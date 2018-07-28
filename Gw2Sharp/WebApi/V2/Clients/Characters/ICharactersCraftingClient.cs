using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters crafting endpoint.
    /// </summary>
    public interface ICharactersCraftingClient :
        IAuthenticatedClient<CharactersCrafting>,
        IBlobClient<CharactersCrafting>
    {
    }
}
