using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is bulk expandable.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    /// <typeparam name="TId">The id value type.</typeparam>
    public interface IBulkExpandableClient<TObject, TId> : IEndpointClient where TObject : IIdentifiable<TId>
    {
        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <param name="id">The entry id.</param>
        /// <returns>The entry.</returns>
        Task<TObject> Get(TId id);

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        Task<TObject> Get(TId id, CancellationToken cancellationToken);

        /// <summary>
        /// Requests a single entry by id with the detailed response info.
        /// </summary>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        Task<IApiV2Response<TObject>> GetWithResponse(TId id, CancellationToken cancellationToken);

        /// <summary>
        /// Requests all ids.
        /// </summary>
        /// <returns>The list of available ids.</returns>
        Task<IReadOnlyList<TId>> Ids();

        /// <summary>
        /// Requests all ids.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The list of available ids.</returns>
        Task<IReadOnlyList<TId>> Ids(CancellationToken cancellationToken);

        /// <summary>
        /// Requests all ids with the detailed response info.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The list of available ids.</returns>
        Task<IApiV2Response<IReadOnlyList<TId>>> IdsWithResponse(CancellationToken cancellationToken);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <param name="ids">The entry ids.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Many(IEnumerable<TId> ids);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Many(IEnumerable<TId> ids, CancellationToken cancellationToken);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion) with the detailed response info.
        /// </summary>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<IApiV2Response<IReadOnlyList<TObject>>>> ManyWithResponse(IEnumerable<TId> ids, CancellationToken cancellationToken);
    }
}
