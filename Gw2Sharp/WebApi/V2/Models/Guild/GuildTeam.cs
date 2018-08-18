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
        public IReadOnlyList<GuildTeamMember> Members { get; set; }

        /// <summary>
        /// The team name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The team state.
        /// </summary>
        public ApiEnum<GuildTeamState> State { get; set; }

        /// <summary>
        /// The team aggregate.
        /// </summary>
        public PvpStatsAggregate Aggregate { get; set; }

        /// <summary>
        /// The team ladders.
        /// </summary>
        public PvpStatsLadders Ladders { get; set; }

        /// <summary>
        /// The team games.
        /// </summary>
        public IReadOnlyList<GuildTeamGame> Games { get; set; }

        /// <summary>
        /// The team seasons.
        /// If no seasons are available, this value is null.
        /// </summary>
        public IReadOnlyList<GuildTeamSeason> Seasons { get; set; }
    }
}
