namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account finisher.
    /// </summary>
    public class AccountFinisher : IIdentifiable<int>
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Finishers"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Indicates if the finisher is permanent or temporary.
        /// </summary>
        public bool Permanent { get; set; }

        /// <summary>
        /// The number of finishers remaining.
        /// If the finisher is not temporary, this value is <see langword="null"/>.
        /// </summary>
        public int? Quantity { get; set; }
    }
}
