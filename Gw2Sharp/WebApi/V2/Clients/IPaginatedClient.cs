using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is paginated.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IPaginatedClient<TObject> : IEndpointClient
    {
        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Page(int page);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Page(int page, int pageSize);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken);

        /// <summary>
        /// Requests a page of entries with a specific page size.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The entries.</returns>
        Task<IReadOnlyList<TObject>> Page(int page, CancellationToken cancellationToken, int pageSize);

        /// <summary>
        /// Requests a page of entries with a specific page size with the detailed response info.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The entries.</returns>
        Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken);

        /// <summary>
        /// Requests a page of entries with a specific page size with the detailed response info.
        /// </summary>
        /// <param name="page">The page number (zero-indexed).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The entries.</returns>
        Task<IApiV2Response<IReadOnlyList<TObject>>> PageWithResponse(int page, CancellationToken cancellationToken, int pageSize);
    }
}
