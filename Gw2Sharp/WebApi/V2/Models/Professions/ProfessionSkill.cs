namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the profession skill.
    /// </summary>
    public class ProfessionSkill
    {
        /// <summary>
        /// The profession skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The profession skill slot.
        /// </summary>
        public ApiEnum<SkillSlot> Slot { get; set; } = new ApiEnum<SkillSlot>();

        /// <summary>
        /// The profession skill type.
        /// </summary>
        public ApiEnum<SkillType> Type { get; set; } = new ApiEnum<SkillType>();

        /// <summary>
        /// The required source profession id.
        /// This value is <c>null</c> if the profession skill doesn't require a specific profession.
        /// </summary>
        public string Source { get; set; } = string.Empty;
    }
}
