using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account achievement.
    /// </summary>
    public class AccountAchievement : IIdentifiable<int>
    {
        /// <summary>
        /// The achievement id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the unlocked achievement bits.
        /// If the achievement does not support bits, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int> Bits { get; set; }

        /// <summary>
        /// The current achievement progression.
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// The maximum achievement progression.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Whether or not the achievement is completed.
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// The number of times the achievement has been repeatedly completed.
        /// If the achievement is not repeatable, this value is <c>null</c>.
        /// </summary>
        public int? Repeated { get; set; }

        /// <summary>
        /// Whether or not the achievement is unlocked.
        /// If the achievement is does not support locking, this value is <c>null</c> and the achievement is not locked.
        /// </summary>
        public bool? Unlocked { get; set; }
    }
}
