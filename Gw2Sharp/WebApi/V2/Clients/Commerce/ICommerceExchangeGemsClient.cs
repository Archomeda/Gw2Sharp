namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems endpoint.
    /// </summary>
    public interface ICommerceExchangeGemsClient
    {
        /// <summary>
        /// Requests commerce exchange information with the specified gems quantity.
        /// </summary>
        /// <param name="quantity">The gems quantity.</param>
        /// <returns>The commerce exchange coins quantity client.</returns>
        ICommerceExchangeGemsQuantityClient Quantity(int quantity);
    }
}
