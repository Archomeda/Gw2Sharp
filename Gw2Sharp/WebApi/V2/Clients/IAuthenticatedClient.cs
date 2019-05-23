namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client that is authenticated.
    /// </summary>
    /// <typeparam name="TObject">The response object type.</typeparam>
    public interface IAuthenticatedClient<TObject> : IEndpointClient
        where TObject : IApiV2Object
    {
    }
}
