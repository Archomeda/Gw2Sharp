using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild team game.
    /// </summary>
    public class GuildTeamGame
    {
        //TODO: Check if all properties are actually correct.

        /// <summary>
        /// The game id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The map id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Maps"/>.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// The start time.
        /// </summary>
        public DateTimeOffset Started { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        public DateTimeOffset Ended { get; set; }

        /// <summary>
        /// The result.
        /// </summary>
        public ApiEnum<PvpResult> Result { get; set; } = new ApiEnum<PvpResult>();

        /// <summary>
        /// The team.
        /// </summary>
        public ApiEnum<PvpTeam> Team { get; set; } = new ApiEnum<PvpTeam>();

        /// <summary>
        /// The team scores.
        /// </summary>
        public PvpTeamScores Scores { get; set; } = new PvpTeamScores();

        /// <summary>
        /// The rating type.
        /// </summary>
        public ApiEnum<PvpRatingType> RatingType { get; set; } = new ApiEnum<PvpRatingType>();
    }
}
