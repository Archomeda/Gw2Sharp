using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a dungeon.
    /// </summary>
    public class Dungeon : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The dungeon id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The dungeon paths.
        /// </summary>
        public IReadOnlyList<DungeonPath> Paths { get; set; } = new List<DungeonPath>();
    }
}
