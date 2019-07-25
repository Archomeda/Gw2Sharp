using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint bulk with support for all clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointPaginatedBlobClient<TObject> : BaseEndpointClient<IApiV2ObjectList<TObject>>, IBlobClient<IApiV2ObjectList<TObject>>, IPaginatedClient<TObject>
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        protected BaseEndpointPaginatedBlobClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <summary>
        /// Creates a new base endpoint bulk with pagination support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        protected BaseEndpointPaginatedBlobClient(IConnection connection, IGw2Client gw2Client, params string[] replaceSegments) :
            base(connection, gw2Client, replaceSegments)
        { }

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> GetAsync(CancellationToken cancellationToken = default) =>
            this.RequestGetAsync(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page, CancellationToken cancellationToken = default) =>
            this.RequestPageAsync(page, cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2ObjectList<TObject>> PageAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
            this.RequestPageAsync(page, cancellationToken, pageSize);
    }
}
