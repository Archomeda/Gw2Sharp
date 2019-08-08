using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP standing.
    /// </summary>
    public class PvpStanding : ApiV2BaseObject
    {
        /// <summary>
        /// The PvP standing season id.
        /// Can be resolved against <see cref="IPvpClient.Seasons"/>.
        /// </summary>
        public Guid SeasonId { get; set; }

        /// <summary>
        /// The current PvP standing record.
        /// </summary>
        public PvpStandingRecord Current { get; set; } = new PvpStandingRecord();

        /// <summary>
        /// The best PvP standing record.
        /// </summary>
        public PvpStandingRecord Best { get; set; } = new PvpStandingRecord();
    }
}
