namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a container item.
    /// </summary>
    public class ItemContainerDetails
    {
        /// <summary>
        /// The container item type.
        /// </summary>
        public ApiEnum<ItemContainerType> Type { get; set; }
    }
}
