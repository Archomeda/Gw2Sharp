using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id equipment tabs endpoint.
    /// </summary>
    public interface ICharactersIdEquipmentTabsClient :
        IAuthenticatedClient,
        IAllExpandableClient<CharacterEquipmentTabSlot>,
        IBulkExpandableClient<CharacterEquipmentTabSlot, int>,
        IPaginatedClient<CharacterEquipmentTabSlot>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }

        /// <summary>
        /// The active equipment tab.
        /// </summary>
        ICharactersIdEquipmentTabsActiveClient Active { get; }
    }
}
