
namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement skin bit.
    /// </summary>
    public class AchievementSkinBit : AchievementBit, IIdentifiable<int>
    {
        /// <summary>
        /// The skin id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int Id { get; set; }
    }
}
