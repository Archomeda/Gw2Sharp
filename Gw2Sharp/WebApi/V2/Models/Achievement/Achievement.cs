using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement.
    /// </summary>
    public class Achievement : IIdentifiable<int>
    {
        /// <summary>
        /// The achievement id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The achievement icon.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// The achievement name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The achievement description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The achievement requirement.
        /// </summary>
        public string Requirement { get; set; } = string.Empty;

        /// <summary>
        /// The locked text for the achievement.
        /// </summary>
        public string LockedText { get; set; } = string.Empty;

        /// <summary>
        /// The achievement type.
        /// </summary>
        public ApiEnum<AchievementType> Type { get; set; } = new ApiEnum<AchievementType>();

        /// <summary>
        /// The achievement flags.
        /// </summary>
        public IReadOnlyList<ApiEnum<AchievementFlag>> Flags { get; set; } = new List<ApiEnum<AchievementFlag>>();

        /// <summary>
        /// Gets the achievement bits.
        /// If the achievement does not have any bits, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<AchievementBit>? Bits { get; set; }

        /// <summary>
        /// The achievement tiers.
        /// If the achievement does not have any tiers, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<AchievementTier>? Tiers { get; set; }

        /// <summary>
        /// The achievement prerequisites.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// If the achievement does not have any prerequisites, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int>? Prerequisites { get; set; }

        /// <summary>
        /// The maximum amount of achievement points that can be awarded from repeatedly completing the achievement.
        /// If the achievement is not repeatable, this value is <c>null</c>.
        /// </summary>
        public int? PointCap { get; set; }

        /// <summary>
        /// The achievement rewards.
        /// If the achievement does not have any rewards, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<AchievementReward>? Rewards { get; set; }
    }
}
