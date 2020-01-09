using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters specializations endpoint.
    /// </summary>
    [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
    public class CharactersSpecializations : ApiV2BaseObject
    {
        /// <summary>
        /// The character specializations.
        /// </summary>
        [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
        public CharacterSpecializations Specializations { get; set; } = new CharacterSpecializations();
    }
}
