using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint blob clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointBlobClient<TObject> : BaseEndpointClient<TObject>, IBlobClient<TObject>
    {
        /// <summary>
        /// Creates a new base endpoint blob client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBlobClient(IConnection connection) : base(connection) { }

        /// <summary>
        /// Creates a new base endpoint blob client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client implements an invalid combination of <see cref="IEndpointClient"/> interfaces.</exception>
        public BaseEndpointBlobClient(IConnection connection, params string[] replaceSegments) : base(connection, replaceSegments) { }

        /// <inheritdoc />
        public virtual Task<TObject> Get() =>
            this.RequestGet();

        /// <inheritdoc />
        public virtual Task<TObject> Get(CancellationToken cancellationToken) =>
            this.RequestGet(cancellationToken);

        /// <inheritdoc />
        public virtual Task<IApiV2Response<TObject>> GetWithResponse(CancellationToken cancellationToken) =>
            this.RequestGetWithResponse(cancellationToken);
    }
}
