namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a daily crafting.
    /// </summary>
    public class DailyCrafting : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The daily crafting id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
