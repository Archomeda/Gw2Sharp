namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id hero points endpoint.
    /// </summary>
    public interface ICharactersIdHeroPointsClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<string>>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
