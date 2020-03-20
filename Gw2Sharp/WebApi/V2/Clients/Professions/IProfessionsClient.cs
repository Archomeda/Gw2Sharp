using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 professions endpoint.
    /// </summary>
    public interface IProfessionsClient :
        IAllExpandableClient<Profession>,
        IBulkExpandableClient<Profession, string>,
        IBulkAliasExpandableClient<Profession, ProfessionType>,
        ILocalizedClient<Profession>,
        IPaginatedClient<Profession>
    {
    }
}
