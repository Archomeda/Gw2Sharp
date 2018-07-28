using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint bulk with support for all clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointPaginatedBlobClient<TObject> : BaseEndpointClient<IReadOnlyList<TObject>>, IBlobClient<IReadOnlyList<TObject>>, IPaginatedClient<TObject>
    {
        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointPaginatedBlobClient(IConnection connection) : base(connection) { }

        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointPaginatedBlobClient(IConnection connection, params string[] replaceSegments) : base(connection, replaceSegments) { }

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Get() =>
            this.RequestGet();

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Get(CancellationToken cancellationToken) =>
            this.RequestGet(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> GetWithResponse(CancellationToken cancellationToken) =>
            this.RequestGetWithResponse(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page) =>
            this.RequestPage(page);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, int pageSize) =>
            this.RequestPage(page, pageSize);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken) =>
            this.RequestPage(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPage(page, cancellationToken, pageSize);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken) =>
            this.RequestPageWithResponse(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageWithResponse(page, cancellationToken, pageSize);
    }
}
