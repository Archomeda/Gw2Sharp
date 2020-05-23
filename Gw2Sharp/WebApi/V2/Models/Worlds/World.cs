namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a world.
    /// </summary>
    public class World : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The world id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The world name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The world population.
        /// </summary>
        public ApiEnum<WorldPopulation> Population { get; set; } = new ApiEnum<WorldPopulation>();
    }
}
