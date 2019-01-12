namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a dungeon path.
    /// </summary>
    public class DungeonPath
    {
        /// <summary>
        /// The dungeon path id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The dungeon path type.
        /// </summary>
        public ApiEnum<DungeonPathType> Type { get; set; } = new ApiEnum<DungeonPathType>();
    }
}
