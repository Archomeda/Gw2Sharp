using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters endpoint.
    /// </summary>
    public interface ICharactersClient :
        IAllExpandableClient<Character>,
        IAuthenticatedClient,
        IBulkExpandableClient<Character, string>,
        IPaginatedClient<Character>
    {
        /// <summary>
        /// Gets a character by name.
        /// </summary>
        ICharactersIdClient this[string characterName] { get; }
    }
}
