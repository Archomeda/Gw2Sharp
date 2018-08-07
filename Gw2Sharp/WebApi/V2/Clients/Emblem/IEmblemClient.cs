namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem endpoint.
    /// </summary>
    public interface IEmblemClient : IClient
    {
        /// <summary>
        /// Gets the foreground emblems.
        /// </summary>
        IEmblemForegroundsClient Foregrounds { get; }

        /// <summary>
        /// Gets the background emblems.
        /// </summary>
        IEmblemBackgroundsClient Backgrounds { get; }
    }
}
