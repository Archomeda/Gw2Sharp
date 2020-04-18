namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mounts endpoint.
    /// </summary>
    public interface IMountsClient
    {
        /// <summary>
        /// Gets the mount skins.
        /// </summary>
        IMountsSkinsClient Skins { get; }

        /// <summary>
        /// Gets the mount types.
        /// </summary>
        IMountsTypesClient Types { get; }
    }
}
