using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search output endpoint.
    /// </summary>
    [EndpointPath("recipes/search")]
    public class RecipesSearchOutputClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IRecipesSearchOutputClient
    {
        private readonly int output;

        /// <summary>
        /// Creates a new <see cref="RecipesSearchOutputClient"/> that is used for the API v2 recipes search output endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="output">The output item id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal RecipesSearchOutputClient(IConnection connection, IGw2Client gw2Client, int output) :
            base(connection, gw2Client)
        {
            this.output = output;
        }

        /// <inheritdoc />
        [EndpointPathParameter("output")]
        public virtual int Output => this.output;
    }
}
