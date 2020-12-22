namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a WvW upgrade tier upgrade.
    /// </summary>
    public class WvwUpgradeTierUpgrade : ApiV2BaseObject
    {
        /// <summary>
        /// The upgrade name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The upgrade description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The upgrade icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }
    }
}
