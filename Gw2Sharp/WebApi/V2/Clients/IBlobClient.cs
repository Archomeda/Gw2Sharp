using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that has a blob on the main endpoint.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IBlobClient<TObject> : IEndpointClient
    {
        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <returns>The blob data.</returns>
        Task<TObject> Get();

        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        Task<TObject> Get(CancellationToken cancellationToken);

        /// <summary>
        /// Requests the main blob data from this endpoint with the detailed response info.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        Task<IApiV2Response<TObject>> GetWithResponse(CancellationToken cancellationToken);
    }
}
