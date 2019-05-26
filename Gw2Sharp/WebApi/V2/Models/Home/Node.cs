namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a node.
    /// </summary>
    public class Node : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The node id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
