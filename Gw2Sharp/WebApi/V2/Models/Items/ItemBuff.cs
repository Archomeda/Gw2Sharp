namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An item buff.
    /// </summary>
    public class ItemBuff
    {
        /// <summary>
        /// The buff skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// The buff description.
        /// </summary>
        public string Description { get; set; }
    }
}
