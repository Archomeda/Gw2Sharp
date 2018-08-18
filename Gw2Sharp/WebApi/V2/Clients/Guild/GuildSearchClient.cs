namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search endpoint.
    /// </summary>
    [EndpointPath("guild/search")]
    public class GuildSearchClient : BaseClient, IGuildSearchClient
    {
        /// <summary>
        /// Creates a new <see cref="GuildSearchClient"/> that is used for the API v2 guild search endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public GuildSearchClient(IConnection connection) : base(connection) { }

        /// <inheritdoc />
        public virtual IGuildSearchNameClient Name(string name) => new GuildSearchNameClient(this.Connection, name);
    }
}
