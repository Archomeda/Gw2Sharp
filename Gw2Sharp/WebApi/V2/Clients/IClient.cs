namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements a client.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Provides the client connection to make web requests.
        /// </summary>
        /// <value>
        /// The client connection.
        /// </value>
        IConnection Connection { get; }
    }
}
