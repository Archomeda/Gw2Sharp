using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters skills endpoint.
    /// </summary>
    public class CharactersSkills : ApiV2BaseObject
    {
        /// <summary>
        /// The character skills.
        /// </summary>
        [Obsolete("Deprecated since the build template update on 2019-12-19. Use /v2/characters/:id/buildtabs instead.")]
        public CharacterSkills Skills { get; set; } = new CharacterSkills();
    }
}
