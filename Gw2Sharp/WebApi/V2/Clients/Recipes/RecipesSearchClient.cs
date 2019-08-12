using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search endpoint.
    /// </summary>
    [EndpointPath("recipes/search")]
    public class RecipesSearchClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IRecipesSearchClient
    {
        /// <summary>
        /// Creates a new <see cref="RecipesSearchClient"/> that is used for the API v2 recipes search endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal RecipesSearchClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <summary>
        /// Clones a <see cref="RecipesSearchClient"/> instance.
        /// </summary>
        /// <param name="client">The original client.</param>
        private RecipesSearchClient(RecipesSearchClient client)
            : this(client.Connection, client.Gw2Client!)
        {
            this.ParamInput = client.ParamInput;
            this.ParamOutput = client.ParamOutput;
        }


        /// <inheritdoc />
        [EndpointPathParameter("input")]
        public int? ParamInput { get; protected set; }

        /// <inheritdoc />
        [EndpointPathParameter("output")]
        public int? ParamOutput { get; protected set; }


        /// <inheritdoc />
        public IRecipesSearchClient Input(int inputItemId)
        {
            return new RecipesSearchClient(this)
            {
                ParamInput = inputItemId,
                ParamOutput = null
            };
        }

        /// <inheritdoc />
        public IRecipesSearchClient Output(int outputItemId)
        {
            return new RecipesSearchClient(this)
            {
                ParamInput = null,
                ParamOutput = outputItemId
            };
        }


        /// <inheritdoc />
        public override Task<IApiV2ObjectList<int>> GetAsync(CancellationToken cancellationToken = default)
        {
            if (this.ParamInput == null && this.ParamOutput == null)
                throw new InvalidOperationException("Either ParamInput or ParamOutput must be specified");
            return base.GetAsync(cancellationToken);
        }
    }
}
