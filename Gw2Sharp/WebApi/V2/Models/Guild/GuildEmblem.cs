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
        public GuildEmblemBackground Background { get; set; } = new GuildEmblemBackground();

        /// <summary>
        /// The emblem foreground.
        /// </summary>
        public GuildEmblemForeground Foreground { get; set; } = new GuildEmblemForeground();

        /// <summary>
        /// The emblem flags.
        /// </summary>
        public ApiFlags<GuildEmblemFlag> Flags { get; set; } = new ApiFlags<GuildEmblemFlag>();
    }
}
