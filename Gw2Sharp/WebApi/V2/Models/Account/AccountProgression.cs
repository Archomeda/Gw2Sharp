namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account progression.
    /// </summary>
    public class AccountProgression
    {
        /// <summary>
        /// The progression id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The progression value.
        /// </summary>
        public int Value { get; set; }
    }
}
