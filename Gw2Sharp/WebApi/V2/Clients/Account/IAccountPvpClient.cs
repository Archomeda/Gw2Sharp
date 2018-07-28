namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP endpoint.
    /// </summary>
    public interface IAccountPvpClient : IClient
    {
        /// <summary>
        /// Gets detailed information about the unlocked PvP points.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountPvpHeroesClient Heroes { get; }
    }
}
