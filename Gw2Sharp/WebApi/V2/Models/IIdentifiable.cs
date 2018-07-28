namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An interface for usage with a type that is identifiable with a unique id.
    /// </summary>
    /// <typeparam name="T">The id type.</typeparam>
    public interface IIdentifiable<T>
    {
        /// <summary>
        /// The unique id.
        /// </summary>
        T Id { get; set; }
    }
}
