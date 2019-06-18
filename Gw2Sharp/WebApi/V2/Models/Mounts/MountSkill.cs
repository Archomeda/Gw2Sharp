namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mount skill.
    /// </summary>
    public class MountSkill
    {
        /// <summary>
        /// The mount skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mount skill slot.
        /// </summary>
        public ApiEnum<SkillSlot> Slot { get; set; } = new ApiEnum<SkillSlot>();
    }
}
