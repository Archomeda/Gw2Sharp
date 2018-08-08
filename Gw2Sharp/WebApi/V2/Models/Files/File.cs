namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a file.
    /// </summary>
    public class File : IIdentifiable<string>
    {
        /// <summary>
        /// The file id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The file icon.
        /// </summary>
        public string Icon { get; set; }
    }
}
