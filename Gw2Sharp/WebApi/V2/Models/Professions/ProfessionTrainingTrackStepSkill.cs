namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a skill profession training track step.
    /// </summary>
    public class ProfessionTrainingTrackStepSkill : ProfessionTrainingTrackStep
    {
        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int SkillId { get; set; }
    }
}
