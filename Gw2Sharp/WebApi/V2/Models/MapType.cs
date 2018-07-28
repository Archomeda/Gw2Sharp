using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a map type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [DefaultValue(Unknown)]
    public enum MapType
    {
        /// <summary>
        /// An unknown map type. Used as fallback.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Redirect map type, e.g. when logging in while in a PvP match.
        /// </summary>
        Redirect = 0,

        /// <summary>
        /// Character create map type.
        /// </summary>
        CharacterCreate = 1,

        /// <summary>
        /// PvP map type.
        /// </summary>
        Pvp = 2,

        /// <summary>
        /// GvG map type. Unused.
        /// Quote from lye: "lol unused ;_;".
        /// </summary>
        Gvg = 3,

        /// <summary>
        /// Instance map type, e.g. dungeons and story content.
        /// </summary>
        Instance = 4,

        /// <summary>
        /// Public map type, e.g. open world.
        /// </summary>
        Public = 5,

        /// <summary>
        /// Tournament map type. Probably unused.
        /// </summary>
        Tournament = 6,

        /// <summary>
        /// Tutorial map type. Probably unused.
        /// </summary>
        Tutorial = 7,

        /// <summary>
        /// User tournament map type. Probably unused.
        /// </summary>
        UserTournament = 8,

        /// <summary>
        /// Eternal Battlegrounds (WvW) map type.
        /// </summary>
        Center = 9,

        /// <summary>
        /// Eternal Battlegrounds (WvW) map type.
        /// </summary>
        EternalBattlegrouns = Center,

        /// <summary>
        /// Blue Borderlands (WvW) map type.
        /// </summary>
        BlueHome = 10,

        /// <summary>
        /// Blue Borderlands (WvW) map type.
        /// </summary>
        BlueBorderlands = BlueHome,

        /// <summary>
        /// Green Borderlands (WvW) map type.
        /// </summary>
        GreenHome = 11,

        /// <summary>
        /// Green Borderlands (WvW) map type.
        /// </summary>
        GreenBorderlands = GreenHome,

        /// <summary>
        /// Red Borderlands (WvW) map type.
        /// </summary>
        RedHome = 12,

        /// <summary>
        /// Red Borderlands (WvW) map type.
        /// </summary>
        RedBorderlands = RedHome,

        /// <summary>
        /// Fortune's Vale. Unused.
        /// </summary>
        FortunesVale = 13,

        /// <summary>
        /// Obsidian Sanctum (WvW) map type.
        /// </summary>
        JumpPuzzle = 14,

        /// <summary>
        /// Obsidian Sanctum (WvW) map type.
        /// </summary>
        ObsidianSanctum = JumpPuzzle,

        /// <summary>
        /// Edge of the Mists (WvW) map type.
        /// </summary>
        EdgeOfTheMists = 15,

        /// <summary>
        /// Mini public map type, e.g. Mistlock Sanctuary.
        /// </summary>
        PublicMini = 16
    }
}
