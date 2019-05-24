namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account luck.
    /// </summary>
    public class AccountLuck
    {
        /// <summary>
        /// The luck id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The luck value.
        /// </summary>
        public int Value { get; set; }
    }
}
