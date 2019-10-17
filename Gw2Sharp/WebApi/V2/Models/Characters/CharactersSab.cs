using System;
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
        public IReadOnlyList<CharacterSabZone> Zones { get; set; } = Array.Empty<CharacterSabZone>();

        /// <summary>
        /// The list of Super Adventure Box unlocks.
        /// </summary>
        public IReadOnlyList<CharacterSabUnlock> Unlocks { get; set; } = Array.Empty<CharacterSabUnlock>();

        /// <summary>
        /// The list of Super Adventure Box songs.
        /// </summary>
        public IReadOnlyList<CharacterSabSong> Songs { get; set; } = Array.Empty<CharacterSabSong>();
    }
}
