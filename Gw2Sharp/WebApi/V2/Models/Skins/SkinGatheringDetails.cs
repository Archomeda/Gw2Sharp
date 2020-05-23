namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a gathering skin.
    /// </summary>
    public class SkinGatheringDetails
    {
        /// <summary>
        /// The gathering skin type.
        /// </summary>
        public ApiEnum<ItemGatheringType> Type { get; set; } = new ApiEnum<ItemGatheringType>();
    }
}
