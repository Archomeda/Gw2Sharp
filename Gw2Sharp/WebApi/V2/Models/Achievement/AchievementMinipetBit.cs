namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement mini pet bit.
    /// </summary>
    public class AchievementMinipetBit : AchievementBit, IIdentifiable<int>
    {
        /// <summary>
        /// The mini id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Minis"/>.
        /// </summary>
        public int Id { get; set; }
    }
}
