namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins endpoint.
    /// </summary>
    public interface ICommerceExchangeCoinsClient : IClient
    {
        /// <summary>
        /// Requests commerce exchange information with the specified coins quantity.
        /// </summary>
        /// <param name="quantity">The coins quantity.</param>
        /// <returns>The commerce exchange coins quantity client.</returns>
        ICommerceExchangeCoinsQuantityClient Quantity(int quantity);
    }
}
