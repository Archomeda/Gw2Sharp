using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 items endpoint.
    /// </summary>
    [EndpointPath("items")]
    [EndpointSchemaVersion("2020-11-17T00:30:00.000Z")]
    public class ItemsClient : BaseEndpointBulkClient<Item, int>, IItemsClient
    {
        /// <summary>
        /// Creates a new <see cref="ItemsClient"/> that is used for the API v2 items endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal ItemsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
