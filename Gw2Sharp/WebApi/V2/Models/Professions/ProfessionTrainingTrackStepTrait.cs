namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a trait profession training track step.
    /// </summary>
    public class ProfessionTrainingTrackStepTrait : ProfessionTrainingTrackStep
    {
        /// <summary>
        /// The trait id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Traits"/>.
        /// </summary>
        public int TraitId { get; set; }
    }
}
