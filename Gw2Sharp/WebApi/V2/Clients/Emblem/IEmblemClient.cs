namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem endpoint.
    /// </summary>
    public interface IEmblemClient
    {
        /// <summary>
        /// Gets the background emblems.
        /// </summary>
        IEmblemBackgroundsClient Backgrounds { get; }

        /// <summary>
        /// Gets the foreground emblems.
        /// </summary>
        IEmblemForegroundsClient Foregrounds { get; }
    }
}
