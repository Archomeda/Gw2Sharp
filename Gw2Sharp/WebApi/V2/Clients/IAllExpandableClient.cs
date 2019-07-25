using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is expandable with the 'all' parameter.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IAllExpandableClient<TObject> : IEndpointClient
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Requests all entries.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        Task<IApiV2ObjectList<TObject>> AllAsync(CancellationToken cancellationToken = default);
    }
}
