using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a dungeon.
    /// </summary>
    public class Dungeon : IIdentifiable<string>
    {
        /// <summary>
        /// The dungeon id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The dungeon paths.
        /// </summary>
        public IReadOnlyList<DungeonPath> Paths { get; set; }
    }
}
