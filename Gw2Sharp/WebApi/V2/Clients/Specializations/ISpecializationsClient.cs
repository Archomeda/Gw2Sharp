using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 specializations endpoint.
    /// </summary>
    public interface ISpecializationsClient :
        IAllExpandableClient<Specialization>,
        IBulkExpandableClient<Specialization, int>,
        ILocalizedClient<Specialization>,
        IPaginatedClient<Specialization>
    {
    }
}
