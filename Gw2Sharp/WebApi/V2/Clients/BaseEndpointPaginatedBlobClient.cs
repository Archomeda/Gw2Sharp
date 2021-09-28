using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint with pagination and bulk all support clients.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public abstract class BaseEndpointPaginatedBlobClient<TObject> : BaseEndpointClient, IBlobClient<IApiV2ObjectList<TObject>>, IPaginatedClient<TObject>
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Creates a new base endpoint bulk with pagination and bulk all support client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// The client implements an invalid combination of <see cref="IEndpointClient"/> interfaces,
        /// or the number of replace segments does not equal the number of path segments given by <see cref="EndpointPathSegmentAttribute"/>.
        /// </exception>
        protected BaseEndpointPaginatedBlobClient(IConnection connection, IGw2Client gw2Client, params string[] replaceSegments) :
            base(connection, gw2Client, replaceSegments) { }

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TObject>> GetAsync(CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Blob().ExecuteAsync<IApiV2ObjectList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TObject>> PageAsync(int page, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Page(page).ExecuteAsync<IApiV2ObjectList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TObject>> PageAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Page(page, pageSize).ExecuteAsync<IApiV2ObjectList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;
    }
}
