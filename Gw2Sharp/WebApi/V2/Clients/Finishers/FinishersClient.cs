using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 finishers endpoint.
    /// </summary>
    [EndpointPath("finishers")]
    public class FinishersClient : BaseEndpointBulkAllClient<Finisher, int>, IFinishersClient
    {
        /// <summary>
        /// Creates a new <see cref="FinishersClient"/> that is used for the API v2 finishers endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal FinishersClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
