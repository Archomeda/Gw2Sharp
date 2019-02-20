using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce delivery endpoint.
    /// </summary>
    [EndpointPath("commerce/delivery")]
    public class CommerceDeliveryClient : BaseEndpointBlobClient<CommerceDelivery>, ICommerceDeliveryClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceDeliveryClient"/> that is used for the API v2 commerce delivery endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceDeliveryClient(IConnection connection) :
            base(connection)
        { }
    }
}
