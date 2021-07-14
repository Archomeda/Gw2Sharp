namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account legendary armory.
    /// </summary>
    public class AccountLegendaryArmory : IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.LegendaryArmory"/> and <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The number of copies that are available.
        /// </summary>
        public int Count { get; set; }
    }
}
