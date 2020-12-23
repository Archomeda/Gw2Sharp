using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character WvW ability.
    /// </summary>
    public class CharacterWvwAbility : IIdentifiable<int>
    {
        /// <summary>
        /// The WvW ability id.
        /// Can be resolved against <see cref="IWvwClient.Abilities"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The WvW ability rank.
        /// </summary>
        public int Rank { get; set; }
    }
}
