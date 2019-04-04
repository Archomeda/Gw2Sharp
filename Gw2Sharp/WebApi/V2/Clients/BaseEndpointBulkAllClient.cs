using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint bulk with support for all clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    /// <typeparam name="TId">The id value type.</typeparam>
    public abstract class BaseEndpointBulkAllClient<TObject, TId> : BaseEndpointClient<TObject>, IAllExpandableClient<TObject>, IBulkExpandableClient<TObject, TId>, IPaginatedClient<TObject>
        where TObject : object, IIdentifiable<TId>
        where TId : object
    {
        /// <summary>
        /// Creates a new base endpoint bulk with support for all client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBulkAllClient(IConnection connection) :
            base(connection)
        { }

        /// <summary>
        /// Creates a new base endpoint bulk with support for all client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBulkAllClient(IConnection connection, params string[] replaceSegments) :
            base(connection, replaceSegments)
        { }

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> AllAsync() =>
            this.RequestAllAsync<TObject, TId>();

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> AllAsync(CancellationToken cancellationToken) =>
            this.RequestAllAsync<TObject, TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> AllWithResponseAsync(CancellationToken cancellationToken) =>
            this.RequestAllWithResponseAsync<TObject, TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<TObject> GetAsync(TId id) =>
            this.RequestGetAsync<TObject, TId>(id);

        /// <inheritdoc />
        public virtual Task<TObject> GetAsync(TId id, CancellationToken cancellationToken) =>
            this.RequestGetAsync<TObject, TId>(id, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<TObject>> GetWithResponseAsync(TId id, CancellationToken cancellationToken) =>
            this.RequestGetWithResponseAsync<TObject, TId>(id, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TId>> IdsAsync() =>
            this.RequestIdsAsync<TId>();

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TId>> IdsAsync(CancellationToken cancellationToken) =>
            this.RequestIdsAsync<TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TId>>> IdsWithResponseAsync(CancellationToken cancellationToken) =>
            this.RequestIdsWithResponseAsync<TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids) =>
            this.RequestManyAsync<TObject, TId>(ids);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
            this.RequestManyAsync<TObject, TId>(ids, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<IApiV2Response<IReadOnlyList<TObject>>>> ManyWithResponseAsync(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
            this.RequestManyWithResponseAsync<TObject, TId>(ids, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page) =>
            this.RequestPageAsync<TObject, TId>(page);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, int pageSize) =>
            this.RequestPageAsync<TObject, TId>(page, pageSize);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, CancellationToken cancellationToken) =>
            this.RequestPageAsync<TObject, TId>(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageAsync<TObject, TId>(page, cancellationToken, pageSize);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponseAsync(int page, CancellationToken cancellationToken) =>
            this.RequestPageWithResponseAsync<TObject, TId>(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponseAsync(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageWithResponseAsync<TObject, TId>(page, cancellationToken, pageSize);
    }
}
