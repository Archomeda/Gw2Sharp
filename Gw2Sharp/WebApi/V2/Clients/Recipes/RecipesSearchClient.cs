using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search endpoint.
    /// </summary>
    [EndpointPath("recipes/search")]
    public class RecipesSearchClient : Gw2WebApiBaseClient, IRecipesSearchClient
    {
        /// <summary>
        /// Creates a new <see cref="RecipesSearchClient"/> that is used for the API v2 recipes search endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal RecipesSearchClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }


        /// <inheritdoc />
        public IRecipesSearchInputClient Input(int input) => new RecipesSearchInputClient(this.Connection, this.Gw2Client!, input);

        /// <inheritdoc />
        public IRecipesSearchOutputClient Output(int output) => new RecipesSearchOutputClient(this.Connection, this.Gw2Client!, output);
    }
}
