namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id quests endpoint.
    /// </summary>
    public interface ICharactersIdQuestsClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<int>>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
