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
        public CharacterGameModeSkills Pve { get; set; } = new CharacterGameModeSkills();

        /// <summary>
        /// The PvP character skills.
        /// </summary>
        public CharacterGameModeSkills Pvp { get; set; } = new CharacterGameModeSkills();

        /// <summary>
        /// The WvW character skills.
        /// </summary>
        public CharacterGameModeSkills Wvw { get; set; } = new CharacterGameModeSkills();
    }
}
