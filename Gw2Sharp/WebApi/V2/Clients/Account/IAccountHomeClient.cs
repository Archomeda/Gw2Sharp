namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home endpoint.
    /// </summary>
    public interface IAccountHomeClient
    {
        /// <summary>
        /// Gets the unlocked home cats.
        /// Each element can be resolved against <see cref="IHomeClient.Cats"/>.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountHomeCatsClient Cats { get; }

        /// <summary>
        /// Gets the unlocked home nodes.
        /// Each element can be resolved against <see cref="IHomeClient.Nodes"/>.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountHomeNodesClient Nodes { get; }
    }
}
