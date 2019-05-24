namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts endpoint.
    /// </summary>
    public interface IAccountMountsClient : IClient
    {
        /// <summary>
        /// Gets the unlocked mount skins.
        /// Each element can be resolved against <see cref="IMountsClient.Skins"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountMountsSkinsClient Skins { get; }

        /// <summary>
        /// Gets the unlocked mount types.
        /// Each element can be resolved against <see cref="IMountsClient.Types"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountMountsTypesClient Types { get; }
    }
}
