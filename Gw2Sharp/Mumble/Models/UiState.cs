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
        IsCompassRotationEnabled = 1 << 2,

        /// <summary>
        /// Whether the game window currently has focus.
        /// </summary>
        DoesGameHaveFocus = 1 << 3,

        /// <summary>
        /// Whether the map the player is currently in, is a competitive mode map.
        /// </summary>
        IsCompetitiveMode = 1 << 4,

        /// <summary>
        /// Whether any textbox input field has focus.
        /// </summary>
        DoesAnyInputHaveFocus = 1 << 5,

        /// <summary>
        /// Whether the player is currently in combat.
        /// </summary>
        IsInCombat = 1 << 6
    }
}
