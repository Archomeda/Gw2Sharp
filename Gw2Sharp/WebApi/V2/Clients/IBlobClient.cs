using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that has a blob on the main endpoint.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IBlobClient<TObject> : IEndpointClient
        where TObject : IApiV2Object
    {
        /// <summary>
        /// Requests the main blob data from this endpoint.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The blob data.</returns>
        Task<TObject> GetAsync(CancellationToken cancellationToken = default);
    }
}
