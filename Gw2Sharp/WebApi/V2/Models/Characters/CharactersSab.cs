using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters Super Adventure Box endpoint.
    /// </summary>
    public class CharactersSab : ApiV2BaseObject
    {
        /// <summary>
        /// The list of Super Adventure Box zones.
        /// </summary>
        public IReadOnlyList<CharacterSabZone> Zones { get; set; } = new List<CharacterSabZone>();

        /// <summary>
        /// The list of Super Adventure Box unlocks.
        /// </summary>
        public IReadOnlyList<CharacterSabUnlock> Unlocks { get; set; } = new List<CharacterSabUnlock>();

        /// <summary>
        /// The list of Super Adventure Box songs.
        /// </summary>
        public IReadOnlyList<CharacterSabSong> Songs { get; set; } = new List<CharacterSabSong>();
    }
}
