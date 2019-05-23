namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a subtoken creation.
    /// </summary>
    public class CreateSubtoken : ApiV2BaseObject
    {
        /// <summary>
        /// The subtoken.
        /// </summary>
        public string Subtoken { get; set; } = string.Empty;
    }
}
