using System;

namespace Gw2Sharp.Mumble.Models
{
    /// <summary>
    /// The UI state.
    /// </summary>
    [Flags]
    internal enum UiState : uint
    {
        /// <summary>
        /// Whether the map is currently open.
        /// </summary>
        IsMapOpen = 1 << 0,

        /// <summary>
        /// Whether the compass is currently positioned in the top right corner.
        /// </summary>
        IsCompassTopRight = 1 << 1,

        /// <summary>
        /// Whether the compass has its rotation currently enabled.
        /// </summary>
        IsCompassRotationEnabled = 1 << 2
    }
}
