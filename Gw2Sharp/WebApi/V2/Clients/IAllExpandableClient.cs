using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is expandable with the 'all' parameter.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IAllExpandableClient<TObject> : IEndpointClient
    {
        /// <summary>
        /// Requests all entries.
        /// </summary>
        /// <returns>All entries.</returns>
        Task<IReadOnlyList<TObject>> AllAsync();

        /// <summary>
        /// Requests all entries.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        Task<IReadOnlyList<TObject>> AllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Requests all entries with the detailed response info.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        Task<IApiV2Response<IReadOnlyList<TObject>>> AllWithResponseAsync(CancellationToken cancellationToken);
    }
}
