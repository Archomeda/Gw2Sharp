namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// The chat link type.
    /// </summary>
    public enum ChatLinkType
    {
        /// <summary>
        /// A coin chat link type.
        /// According to the wiki it's currently disabled.
        /// </summary>
        Coin = 0x1,

        /// <summary>
        /// An item chat link type.
        /// </summary>
        Item = 0x2,

        /// <summary>
        /// An NPC text chat link type.
        /// According to the wiki it's currently disabled.
        /// </summary>
        NpcText = 0x3,

        /// <summary>
        /// A point of interest chat link type.
        /// </summary>
        PointOfInterest = 0x4,

        /// <summary>
        /// A PvP game chat link type.
        /// </summary>
        PvpGame = 0x5,

        /// <summary>
        /// A skill chat link type.
        /// </summary>
        Skill = 0x6,

        /// <summary>
        /// A trait chat link type.
        /// </summary>
        Trait = 0x7,

        /// <summary>
        /// A user chat link type.
        /// </summary>
        User = 0x8,

        /// <summary>
        /// A recipe chat link type.
        /// </summary>
        Recipe = 0x9,

        /// <summary>
        /// A wardrobe skin chat link type.
        /// </summary>
        Skin = 0xA,

        /// <summary>
        /// An outfit chat link type.
        /// </summary>
        Outfit = 0xB,

        /// <summary>
        /// A WvW objective chat link type.
        /// </summary>
        WvwObjective = 0xC
    }
}

