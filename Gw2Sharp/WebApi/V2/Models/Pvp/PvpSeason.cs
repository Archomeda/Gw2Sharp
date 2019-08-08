using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season.
    /// </summary>
    public class PvpSeason : ApiV2BaseObject, IIdentifiable<Guid>
    {
        /// <summary>
        /// The PvP season id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The PvP season name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The PvP season start date.
        /// </summary>
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// The PvP season end date.
        /// </summary>
        public DateTimeOffset End { get; set; }

        /// <summary>
        /// Whether this PvP season is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The PvP season divisions.
        /// </summary>
        public IReadOnlyList<PvpSeasonDivision> Divisions { get; set; } = new List<PvpSeasonDivision>();

        /// <summary>
        /// The PvP season ranks.
        /// </summary>
        public IReadOnlyList<PvpSeasonRank> Ranks { get; set; } = new List<PvpSeasonRank>();

        /// <summary>
        /// The PvP season leaderboards.
        /// </summary>
        public IReadOnlyDictionary<string, PvpSeasonLeaderboard> Leaderboards { get; set; } = new Dictionary<string, PvpSeasonLeaderboard>();
    }
}
