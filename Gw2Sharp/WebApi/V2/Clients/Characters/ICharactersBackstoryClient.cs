using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters backstory endpoint.
    /// </summary>
    public interface ICharactersBackstoryClient :
        IAuthenticatedClient<CharactersBackstory>,
        IBlobClient<CharactersBackstory>
    {
    }
}
