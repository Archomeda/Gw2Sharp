namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 home endpoint.
    /// </summary>
    public interface IHomeClient
    {
        /// <summary>
        /// Gets the cats.
        /// </summary>
        IHomeCatsClient Cats { get; }

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        IHomeNodesClient Nodes { get; }
    }
}
