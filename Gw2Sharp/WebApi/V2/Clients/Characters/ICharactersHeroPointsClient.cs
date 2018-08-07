using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters hero points endpoint.
    /// </summary>
    public interface ICharactersHeroPointsClient :
        IAuthenticatedClient<IReadOnlyList<string>>,
        IBlobClient<IReadOnlyList<string>>
    {
        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }
    }
}
