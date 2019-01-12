namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character Super Adventure Box unlock
    /// </summary>
    public class CharacterSabUnlock : IIdentifiable<int>
    {
        /// <summary>
        /// The unlock id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unlock id in text form.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
