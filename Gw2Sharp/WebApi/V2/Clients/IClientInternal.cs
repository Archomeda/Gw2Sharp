namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements a client, consumed internally.
    /// </summary>
    internal interface IClientInternal
    {
        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        IConnection Connection { get; }
    }
}
