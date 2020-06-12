using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild team season.
    /// </summary>
    public class GuildTeamSeason
    {
        /// <summary>
        /// The season id.
        /// Can be resolved against <see cref="IPvpClient.Seasons"/>.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The amount of wins.
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// The amount of losses.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// The rating.
        /// </summary>
        public int Rating { get; set; }
    }
}
