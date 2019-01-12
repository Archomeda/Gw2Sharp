namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represent a guild upgrade currency cost.
    /// </summary>
    public class GuildUpgradeCostCurrency : GuildUpgradeCost
    {
        /// <summary>
        /// The cost name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
