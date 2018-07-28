using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint bulk clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    /// <typeparam name="TId">The id value type.</typeparam>
    public abstract class BaseEndpointBulkClient<TObject, TId> : BaseEndpointClient<TObject>, IBulkExpandableClient<TObject, TId>, IPaginatedClient<TObject>
        where TObject : IIdentifiable<TId>
    {
        /// <summary>
        /// Creates a new base endpoint bulk client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBulkClient(IConnection connection) : base(connection) { }

        /// <summary>
        /// Creates a new base endpoint bulk client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBulkClient(IConnection connection, params string[] replaceSegments) : base(connection, replaceSegments) { }

        /// <inheritdoc />
        public virtual Task<TObject> Get(TId id) =>
            this.RequestGet<TObject, TId>(id);

        /// <inheritdoc />
        public virtual Task<TObject> Get(TId id, CancellationToken cancellationToken) =>
            this.RequestGet<TObject, TId>(id, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<TObject>> GetWithResponse(TId id, CancellationToken cancellationToken) =>
            this.RequestGetWithResponse<TObject, TId>(id, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TId>> Ids() =>
            this.RequestIds<TId>();

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TId>> Ids(CancellationToken cancellationToken) =>
            this.RequestIds<TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TId>>> IdsWithResponse(CancellationToken cancellationToken) =>
            this.RequestIdsWithResponse<TId>(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Many(IEnumerable<TId> ids) =>
            this.RequestMany<TObject, TId>(ids);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Many(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
            this.RequestMany<TObject, TId>(ids, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<IApiV2Response<IReadOnlyList<TObject>>>> ManyWithResponse(IEnumerable<TId> ids, CancellationToken cancellationToken) =>
            this.RequestManyWithResponse<TObject, TId>(ids, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page) =>
            this.RequestPage<TObject, TId>(page);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, int pageSize) =>
            this.RequestPage<TObject, TId>(page, pageSize);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken) =>
            this.RequestPage<TObject, TId>(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPage<TObject, TId>(page, cancellationToken, pageSize);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken) =>
            this.RequestPageWithResponse<TObject, TId>(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageWithResponse<TObject, TId>(page, cancellationToken, pageSize);
    }
}
