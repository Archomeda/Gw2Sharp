using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild emblem.
    /// </summary>
    public class GuildEmblem
    {
        /// <summary>
        /// The emblem background.
        /// </summary>
        public GuildEmblemBackground Background { get; set; }

        /// <summary>
        /// The emblem foreground.
        /// </summary>
        public GuildEmblemForeground Foreground { get; set; }

        /// <summary>
        /// The emblem flags.
        /// </summary>
        public IReadOnlyList<ApiEnum<GuildEmblemFlag>> Flags { get; set; }
    }
}
