using System;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Additional data for item chat links.
    /// </summary>
    [Flags]
    public enum ItemChatLinkStructAdditionalData
    {
        /// <summary>
        /// No extra data.
        /// </summary>
        None = 0,

        /// <summary>
        /// The item has a custom skin.
        /// </summary>
        Skin = 1 << 7,

        /// <summary>
        /// The item has a first upgrade.
        /// </summary>
        Upgrade1 = 1 << 6,

        /// <summary>
        /// The item has a second upgrade.
        /// </summary>
        Upgrade2 = 1 << 5
    }
}
