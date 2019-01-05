namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Item game type.
    /// </summary>
    public enum ItemGameType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// The item is usable in activities.
        /// </summary>
        Activity,

        /// <summary>
        /// The item is usable in dungeons.
        /// </summary>
        Dungeon,

        /// <summary>
        /// The item is usable in PvE.
        /// </summary>
        Pve,

        /// <summary>
        /// The item is usable in PvP.
        /// </summary>
        Pvp,

        /// <summary>
        /// The item is usable in the PvP lobby.
        /// </summary>
        PvpLobby,

        /// <summary>
        /// The item is usable in WvW.
        /// </summary>
        Wvw
    }
}
