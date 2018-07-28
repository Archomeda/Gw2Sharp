namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character Super Adventure Box song.
    /// </summary>
    public class CharacterSabSong : IIdentifiable<int>
    {
        /// <summary>
        /// The song id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The song id in text form.
        /// </summary>
        public string Name { get; set; }
    }
}
