namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The pet skill.
    /// </summary>
    public class PetSkill
    {
        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }
    }
}
