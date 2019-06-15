namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a map chest.
    /// </summary>
    public class MapChest : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The map chest id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
