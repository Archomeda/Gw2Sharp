namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the profession weapon skill.
    /// </summary>
    public class ProfessionWeaponSkill
    {
        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The weapon skill slot.
        /// </summary>
        public ApiEnum<SkillSlot> Slot { get; set; } = new ApiEnum<SkillSlot>();

        /// <summary>
        /// The required off-hand weapon id.
        /// This value is <c>null</c> if the skill doesn't require an off-hand weapon.
        /// </summary>
        public string Offhand { get; set; } = string.Empty;
    }
}
