using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters skills endpoint.
    /// </summary>
    [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
    public class CharactersSkills : ApiV2BaseObject
    {
        /// <summary>
        /// The character skills.
        /// </summary>
        [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead. To be removed starting with version 0.9.0.")]
        public CharacterSkills Skills { get; set; } = new CharacterSkills();
    }
}
