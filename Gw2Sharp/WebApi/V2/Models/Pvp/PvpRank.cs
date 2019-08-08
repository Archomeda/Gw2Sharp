using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP rank.
    /// </summary>
    public class PvpRank : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The PvP rank id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The PvP finisher item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Finishers"/>.
        /// </summary>
        public int FinisherId { get; set; }

        /// <summary>
        /// The PvP rank name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The PvP rank icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The minimum required PvP level for this rank.
        /// </summary>
        public int MinRank { get; set; }

        /// <summary>
        /// The maximum required PvP level for this rank.
        /// </summary>
        public int MaxRank { get; set; }

        /// <summary>
        /// The PvP levels for this rank.
        /// </summary>
        public IReadOnlyList<PvpRankLevel> Levels { get; set; } = new List<PvpRankLevel>();
    }
}
