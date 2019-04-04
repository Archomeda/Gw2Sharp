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
        where TObject : object
    {
        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public BaseEndpointPaginatedBlobClient(IConnection connection) : base(connection) { }

        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public BaseEndpointPaginatedBlobClient(IConnection connection, params string[] replaceSegments) : base(connection, replaceSegments) { }

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> GetAsync() =>
            this.RequestGetAsync();

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> GetAsync(CancellationToken cancellationToken) =>
            this.RequestGetAsync(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> GetWithResponseAsync(CancellationToken cancellationToken) =>
            this.RequestGetWithResponseAsync(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page) =>
            this.RequestPageAsync(page);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, int pageSize) =>
            this.RequestPageAsync(page, pageSize);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, CancellationToken cancellationToken) =>
            this.RequestPageAsync(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IReadOnlyList<TObject>> PageAsync(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageAsync(page, cancellationToken, pageSize);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponseAsync(int page, CancellationToken cancellationToken) =>
            this.RequestPageWithResponseAsync(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponseAsync(int page, CancellationToken cancellationToken, int pageSize) =>
            this.RequestPageWithResponseAsync(page, cancellationToken, pageSize);
    }
}
