namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins endpoint.
    /// </summary>
    public interface ICommerceExchangeCoinsClient : IClient
    {
        /// <summary>
        /// Gets the commerce exchange coins endpoint with the specified quantity.
        /// </summary>
        ICommerceExchangeCoinsQuantityClient this[int quantity] { get; }
    }
}
