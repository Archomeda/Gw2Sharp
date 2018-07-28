namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account home cat.
    /// </summary>
    public class AccountHomeCat : IIdentifiable<int>
    {
        /// <summary>
        /// The cat id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Cats"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The cat hint.
        /// </summary>
        public string Hint { get; set; }
    }
}
