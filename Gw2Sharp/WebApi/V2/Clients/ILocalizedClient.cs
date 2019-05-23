namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is localized.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface ILocalizedClient<TObject> : IEndpointClient
        where TObject : IApiV2Object
    {
    }
}
