using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Gw2Sharp.Mumble.Models
{
    /// <summary>
    /// The identity.
    /// </summary>
    internal class CharacterIdentity
    {
        /// <summary>
        /// The character name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The character profession.
        /// </summary>
        public ProfessionType Profession { get; set; }

        /// <summary>
        /// The character specialization.
        /// </summary>
        public int Spec { get; set; }

        /// <summary>
        /// The character race.
        /// </summary>
        public RaceType Race { get; set; }

        /// <summary>
        /// The team color id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        public int TeamColorId { get; set; }

        /// <summary>
        /// Whether the commander tag is enabled or not.
        /// </summary>
        public bool Commander { get; set; }

        /// <summary>
        /// The vertical field of view.
        /// </summary>
        public double Fov { get; set; }

        /// <summary>
        /// The UI size.
        /// </summary>
        public UiSize Uisz { get; set; }
    }
}
