namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// Implements a web API client, consumed internally.
    /// </summary>
    internal interface IWebApiClientInternal
    {
        /// <summary>
        /// Gets the client connection to make web requests.
        /// </summary>
        IConnection Connection { get; }
    }
}
