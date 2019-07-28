using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP game.
    /// </summary>
    public class PvpGame : ApiV2BaseObject, IIdentifiable<Guid>
    {
        /// <summary>
        /// The PvP id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The map id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Maps"/>.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// The time when this PvP match started.
        /// </summary>
        public DateTimeOffset Started { get; set; }

        /// <summary>
        /// The time when this PvP match ended.
        /// </summary>
        public DateTimeOffset Ended { get; set; }

        /// <summary>
        /// The PvP match result.
        /// </summary>
        public ApiEnum<PvpResult> Result { get; set; } = new ApiEnum<PvpResult>();

        /// <summary>
        /// The PvP team.
        /// </summary>
        public ApiEnum<PvpTeam> Team { get; set; } = new ApiEnum<PvpTeam>();

        /// <summary>
        /// The profession.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// The PvP rating type.
        /// </summary>
        public ApiEnum<PvpRatingType> RatingType { get; set; } = new ApiEnum<PvpRatingType>();

        /// <summary>
        /// The PvP rating change.
        /// </summary>
        public int RatingChange { get; set; }

        /// <summary>
        /// The season this PvP match belongs to.
        /// Can be resolved against <see cref="IPvpClient.Seasons"/>.
        /// </summary>
        public Guid Season { get; set; }

        /// <summary>
        /// The PvP match scores.
        /// </summary>
        public PvpTeamScores Scores { get; set; } = new PvpTeamScores();
    }
}
