namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a gathering skin.
    /// </summary>
    public class SkinGathering : Skin
    {
        /// <summary>
        /// The gathering details.
        /// </summary>
        public SkinGatheringDetails Details { get; set; } = new SkinGatheringDetails();
    }
}
