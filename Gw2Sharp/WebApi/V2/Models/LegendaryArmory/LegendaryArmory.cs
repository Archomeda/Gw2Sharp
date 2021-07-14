namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a legendary armory.
    /// </summary>
    public class LegendaryArmory : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The maximum number of copies that can be stored.
        /// </summary>
        public int MaxCount { get; set; }
    }
}
