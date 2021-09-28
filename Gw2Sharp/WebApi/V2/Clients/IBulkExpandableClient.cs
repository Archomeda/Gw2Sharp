using System;
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
    public interface IBulkExpandableClient<TObject, TId> : IEndpointClient
        where TObject : IApiV2Object, IIdentifiable<TId>
    {
        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <see langword="null"/>.</exception>
        Task<TObject> GetAsync(TId id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests all ids.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The list of available ids.</returns>
        Task<IApiV2ObjectList<TId>> IdsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <see langword="null"/>.</exception>
        Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);
    }
}
