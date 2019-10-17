using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 skills endpoint.
    /// </summary>
    public interface ISkillsClient :
        IAllExpandableClient<Skill>,
        IBulkExpandableClient<Skill, int>,
        ILocalizedClient<Skill>,
        IPaginatedClient<Skill>
    {
    }
}
