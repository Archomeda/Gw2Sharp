namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters specializations endpoint.
    /// </summary>
    public class CharactersSpecializations : ApiV2BaseObject
    {
        /// <summary>
        /// The character specializations.
        /// </summary>
        public CharacterSpecializations Specializations { get; set; } = new CharacterSpecializations();
    }
}
