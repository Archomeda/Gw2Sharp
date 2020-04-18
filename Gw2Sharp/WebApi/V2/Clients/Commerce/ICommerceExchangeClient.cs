namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange endpoint.
    /// </summary>
    public interface ICommerceExchangeClient
    {
        /// <summary>
        /// Gets the commerce exchange coins client.
        /// </summary>
        ICommerceExchangeCoinsClient Coins { get; }

        /// <summary>
        /// Gets the commerce exchange gems client.
        /// </summary>
        ICommerceExchangeGemsClient Gems { get; }
    }
}
