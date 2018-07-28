namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement reward.
    /// The achievement reward can be <see cref="AchievementCoinsReward"/>, <see cref="AchievementItemReward"/>, <see cref="AchievementMasteryReward"/> or <see cref="AchievementTitleReward"/>.
    /// </summary>
    [CastableType(AchievementRewardType.Coins, typeof(AchievementCoinsReward))]
    [CastableType(AchievementRewardType.Item, typeof(AchievementItemReward))]
    [CastableType(AchievementRewardType.Mastery, typeof(AchievementMasteryReward))]
    [CastableType(AchievementRewardType.Title, typeof(AchievementTitleReward))]
    public class AchievementReward : ICastableType<AchievementReward, AchievementRewardType>
    {
        /// <summary>
        /// The achievement reward type.
        /// </summary>
        public ApiEnum<AchievementRewardType> Type { get; set; }
    }
}
