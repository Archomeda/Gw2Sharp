namespace Gw2Sharp
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

        /// <summary>
        /// Gets the Guild Wars 2 client.
        /// </summary>
        IGw2Client? Gw2Client { get; }
    }
}
