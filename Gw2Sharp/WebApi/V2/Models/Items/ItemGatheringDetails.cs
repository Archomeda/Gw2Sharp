namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a gathering item.
    /// </summary>
    public class ItemGatheringDetails
    {
        /// <summary>
        /// The gathering item type.
        /// </summary>
        public ApiEnum<ItemGatheringType> Type { get; set; }
    }
}
