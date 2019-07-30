using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild team.
    /// </summary>
    public class GuildTeam
    {
        /// <summary>
        /// The guild team id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The team members.
        /// </summary>
        public IReadOnlyList<GuildTeamMember> Members { get; set; } = new List<GuildTeamMember>();

        /// <summary>
        /// The team name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The team state.
        /// </summary>
        public ApiEnum<GuildTeamState> State { get; set; } = new ApiEnum<GuildTeamState>();

        /// <summary>
        /// The team aggregate stats.
        /// </summary>
        public PvpStatsAggregate Aggregate { get; set; } = new PvpStatsAggregate();

        /// <summary>
        /// The team ladders aggregate stats.
        /// </summary>
        public IReadOnlyDictionary<string, PvpStatsAggregate> Ladders { get; set; } = new Dictionary<string, PvpStatsAggregate>();

        /// <summary>
        /// The team games.
        /// </summary>
        public IReadOnlyList<GuildTeamGame> Games { get; set; } = new List<GuildTeamGame>();

        /// <summary>
        /// The team seasons.
        /// If no seasons are available, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<GuildTeamSeason> Seasons { get; set; } = new List<GuildTeamSeason>();
    }
}
