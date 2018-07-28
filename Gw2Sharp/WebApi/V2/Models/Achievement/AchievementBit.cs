namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement bit.
    /// The achievement bit can be <see cref="AchievementItemBit"/>, <see cref="AchievementMinipetBit"/>, <see cref="AchievementSkinBit"/> or <see cref="AchievementTextBit"/>.
    /// </summary>
    [CastableType(AchievementBitType.Item, typeof(AchievementItemBit))]
    [CastableType(AchievementBitType.Minipet, typeof(AchievementMinipetBit))]
    [CastableType(AchievementBitType.Skin, typeof(AchievementSkinBit))]
    [CastableType(AchievementBitType.Text, typeof(AchievementTextBit))]
    public class AchievementBit : ICastableType<AchievementBit, AchievementBitType>
    {
        /// <summary>
        /// The achievement bit type.
        /// </summary>
        public ApiEnum<AchievementBitType> Type { get; set; }
    }
}
