namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems endpoint.
    /// </summary>
    public interface ICommerceExchangeGemsClient : IClient
    {
        /// <summary>
        /// Gets the commerce exchange gems endpoint with the specified quantity.
        /// </summary>
        ICommerceExchangeGemsQuantityClient this[int quantity] { get; }
    }
}
