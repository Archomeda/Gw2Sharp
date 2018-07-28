namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the selected stats on equipment items.
    /// </summary>
    public class EquipmentItemStats : IIdentifiable<int>
    {
        /// <summary>
        /// The itemstat id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Itemstats"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item attributes.
        /// </summary>
        public ItemAttributes Attributes { get; set; }
    }
}
