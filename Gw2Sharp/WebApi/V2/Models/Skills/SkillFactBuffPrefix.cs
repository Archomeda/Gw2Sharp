namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The skill fact buff prefix.
    /// </summary>
    public class SkillFactBuffPrefix
    {
        /// <summary>
        /// The prefix text.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The prefix icon.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The prefix status.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The prefix description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
