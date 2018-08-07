using System.Collections.Generic;

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
        public string Id { get; set; }

        /// <summary>
        /// The dungeon path type.
        /// </summary>
        public ApiEnum<DungeonPathType> Type { get; set; }
    }
}
