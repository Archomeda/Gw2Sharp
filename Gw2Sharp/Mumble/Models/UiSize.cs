using System.ComponentModel;

namespace Gw2Sharp.Mumble.Models
{
    /// <summary>
    /// The in-game UI size.
    /// </summary>
    [DefaultValue(Normal)]
    public enum UiSize
    {
        /// <summary>
        /// Small UI size.
        /// </summary>
        Small = 0,

        /// <summary>
        /// Normal UI size.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Large UI size.
        /// </summary>
        Large = 2,

        /// <summary>
        /// Larger UI size.
        /// </summary>
        Larger = 3
    }
}
