namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the profession training track step.
    /// The training track step can be <see cref="ProfessionTrainingTrackStepSkill"/> or <see cref="ProfessionTrainingTrackStepTrait"/>.
    /// </summary>
    [CastableType(ProfessionTrainingTrackStepType.Skill, typeof(ProfessionTrainingTrackStepSkill))]
    [CastableType(ProfessionTrainingTrackStepType.Trait, typeof(ProfessionTrainingTrackStepTrait))]
    public class ProfessionTrainingTrackStep : ICastableType<ProfessionTrainingTrackStepType, ProfessionTrainingTrackStepType>
    {
        /// <summary>
        /// The cost of the training track step.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The training track step type.
        /// </summary>
        public ApiEnum<ProfessionTrainingTrackStepType> Type { get; set; } = new ApiEnum<ProfessionTrainingTrackStepType>();
    }
}
