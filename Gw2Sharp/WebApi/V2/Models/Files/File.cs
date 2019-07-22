namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a file.
    /// </summary>
    public class File : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The file id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The file icon.
        /// </summary>
        public RenderUrl Icon { get; set; }
    }
}
