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
        where TObject : IApiV2Object, IIdentifiable<TId>
        where TId : notnull
    {
        /// <summary>
        /// Creates a new base endpoint bulk client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">
        /// The client implements an invalid combination of <see cref="IEndpointClient"/> interfaces,
        /// or the number of replace segments does not equal the number of path segments given by <see cref="EndpointPathSegmentAttribute"/>.
        /// </exception>
        protected BaseEndpointBulkClient(IConnection connection, IGw2Client gw2Client, params string[] replaceSegments) :
            base(connection, gw2Client, replaceSegments) { }

        /// <inheritdoc />
        public virtual async Task<TObject> GetAsync(TId id, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Single(id).ExecuteAsync<TObject>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TId>> IdsAsync(CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Ids().ExecuteAsync<IApiV2ObjectList<TId>>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IReadOnlyList<TObject>> ManyAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Many(ids).ExecuteAsync<IReadOnlyList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TObject>> PageAsync(int page, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Page(page).ExecuteAsync<IApiV2ObjectList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;

        /// <inheritdoc />
        public virtual async Task<IApiV2ObjectList<TObject>> PageAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
            (await new RequestBuilder(this, this.Connection, this.Gw2Client).Page(page, pageSize).ExecuteAsync<IApiV2ObjectList<TObject>>(cancellationToken).ConfigureAwait(false)).Content;
    }
}
