namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a quaggan.
    /// </summary>
    public class Quaggan : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The quaggan id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The quaggan image URL.
        /// </summary>
        public RenderUrl Url { get; set; }
    }
}
