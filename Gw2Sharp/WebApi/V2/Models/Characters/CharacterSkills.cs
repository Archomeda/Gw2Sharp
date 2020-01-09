namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the character skills.
    /// </summary>
    public class CharacterSkills
    {
        /// <summary>
        /// The PvE character skills.
        /// </summary>
        public BuildTemplateSkills Pve { get; set; } = new BuildTemplateSkills();

        /// <summary>
        /// The PvP character skills.
        /// </summary>
        public BuildTemplateSkills Pvp { get; set; } = new BuildTemplateSkills();

        /// <summary>
        /// The WvW character skills.
        /// </summary>
        public BuildTemplateSkills Wvw { get; set; } = new BuildTemplateSkills();
    }
}
