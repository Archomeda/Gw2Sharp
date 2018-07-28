namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters skills endpoint.
    /// </summary>
    public class CharactersSkills
    {
        /// <summary>
        /// The character skills.
        /// </summary>
        public CharacterSkills Skills { get; set; }
    }
}
