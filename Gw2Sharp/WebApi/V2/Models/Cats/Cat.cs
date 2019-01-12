namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a cat.
    /// </summary>
    public class Cat : IIdentifiable<int>
    {
        /// <summary>
        /// The cat id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The cat hint.
        /// </summary>
        public string Hint { get; set; } = string.Empty;
    }
}
