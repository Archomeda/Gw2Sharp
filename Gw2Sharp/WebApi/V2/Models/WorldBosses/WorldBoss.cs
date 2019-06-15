namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a world boss.
    /// </summary>
    public class WorldBoss : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The world boss id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
