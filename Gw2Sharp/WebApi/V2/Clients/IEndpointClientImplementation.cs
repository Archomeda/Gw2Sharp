using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An interface that defines the endpoint client implementations.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IEndpointClientImplementation<TObject>
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Requests all entries from this endpoint.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All entries.</returns>
        Task<IApiV2ObjectList<TEndpointObject>> RequestAllAsync<TEndpointObject, TId>(CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : notnull;

        /// <summary>
        /// Requests the list of entry ids from this endpoint.
        /// </summary>
        /// <typeparam name="TId">The entry id type.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Entry ids.</returns>
        Task<IApiV2ObjectList<TId>> RequestIdsAsync<TId>(CancellationToken cancellationToken = default)
            where TId : notnull;

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        Task<TObject> RequestGetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Requests a single entry by id.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="id">The entry id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entry.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
        Task<TEndpointObject> RequestGetAsync<TEndpointObject, TId>(TId id, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : notnull;

        /// <summary>
        /// Requests many entries by their id (a.k.a. bulk expansion).
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="ids">The entry ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
        Task<IReadOnlyList<TEndpointObject>> RequestManyAsync<TEndpointObject, TId>(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
            where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : notnull;

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <typeparam name="TEndpointObject">The endpoint return value type.</typeparam>
        /// <typeparam name="TId">The id value type.</typeparam>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        Task<IApiV2ObjectList<TEndpointObject>> RequestPageAsync<TEndpointObject, TId>(int page, int pageSize = DefaultEndpointClientImplementation<TObject>.MAX_PAGE_SIZE, CancellationToken cancellationToken = default)
                where TEndpointObject : IApiV2Object, IIdentifiable<TId>
            where TId : notnull;

        /// <summary>
        /// Requests a page of blob data with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size (maximum 200).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageSize"/> is not within the accepted boundaries (1 - 200).</exception>
        Task<TObject> RequestPageAsync(int page, int pageSize = DefaultEndpointClientImplementation<TObject>.MAX_PAGE_SIZE, CancellationToken cancellationToken = default);
    }
}
