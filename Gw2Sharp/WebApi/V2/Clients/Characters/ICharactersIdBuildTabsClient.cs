using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id build tabs endpoint.
    /// </summary>
    public interface ICharactersIdBuildTabsClient :
        IAuthenticatedClient,
        IAllExpandableClient<CharacterBuildTabSlot>,
        IBulkExpandableClient<CharacterBuildTabSlot, int>,
        IPaginatedClient<CharacterBuildTabSlot>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }

        /// <summary>
        /// The active build tab.
        /// </summary>
        ICharactersIdBuildTabsActiveClient Active { get; }
    }
}
