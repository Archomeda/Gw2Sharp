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
        where TObject : IApiV2Object, IIdentifiable<TId>
    {
        /// <summary>
        /// Creates a new base endpoint bulk with support for all client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        protected BaseEndpointBulkAllClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <summary>
        /// Creates a new base endpoint bulk with support for all client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        protected BaseEndpointBulkAllClient(IConnection connection, IGw2Client gw2Client, params string[] replaceSegments) :
            base(connection, gw2Client, replaceSegments)
        { }

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> AllAsync() =>
            this.RequestAllAsync<TObject, TId>();

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> AllAsync(CancellationToken cancellationToken) =>
            this.RequestAllAsync<TObject, TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<TObject> GetAsync(TId id) =>
            this.RequestGetAsync<TObject, TId>(id);

        /// <inheritdoc />
        public virtual Task<TObject> GetAsync(TId id, CancellationToken cancellationToken) =>
            this.RequestGetAsync<TObject, TId>(id, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TId>> IdsAsync() =>
            this.RequestIdsAsync<TId>();

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TId>> IdsAsync(CancellationToken cancellationToken) =>
            this.RequestIdsAsync<TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids) =>
            this.RequestManyAsync<TObject, TId>(ids);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
            this.RequestManyAsync<TObject, TId>(ids, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page) =>
            this.RequestPageAsync<TObject, TId>(page);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page, int pageSize) =>
            this.RequestPageAsync<TObject, TId>(page, pageSize);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page, CancellationToken cancellationToken) =>
            this.RequestPageAsync<TObject, TId>(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page, int pageSize, CancellationToken cancellationToken) =>
            this.RequestPageAsync<TObject, TId>(page, cancellationToken, pageSize);
    }
}
