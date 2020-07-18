using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search input endpoint.
    /// </summary>
    [EndpointPath("recipes/search")]
    public class RecipesSearchInputClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IRecipesSearchInputClient
    {
        private readonly int input;

        /// <summary>
        /// Creates a new <see cref="RecipesSearchInputClient"/> that is used for the API v2 recipes search input endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="input">The input item id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal RecipesSearchInputClient(IConnection connection, IGw2Client gw2Client, int input) :
            base(connection, gw2Client)
        {
            this.input = input;
        }

        /// <inheritdoc />
        [EndpointQueryParameter("input")]
        public virtual int Input => this.input;
    }
}
