namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account mastery.
    /// </summary>
    public class AccountMastery : IIdentifiable<int>
    {
        /// <summary>
        /// The mastery id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Masteries"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mastery level.
        /// </summary>
        public int Level { get; set; }
    }
}
