namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A WvW map type.
    /// </summary>
    public enum WvwMapType
    {
        /// <summary>
        /// Unknown map type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Green Borderlands map type.
        /// </summary>
        GreenHome,

        /// <summary>
        /// Green Borderlands map type.
        /// </summary>
        GreenBorderlands = GreenHome,

        /// <summary>
        /// Blue Borderlands map type.
        /// </summary>
        BlueHome,

        /// <summary>
        /// Blue Borderlands map type.
        /// </summary>
        BlueBorderlands = BlueHome,

        /// <summary>
        /// Red Borderlands map type.
        /// </summary>
        RedHome = 12,

        /// <summary>
        /// Red Borderlands map type.
        /// </summary>
        RedBorderlands = RedHome,

        /// <summary>
        /// Eternal Battlegrounds map type.
        /// </summary>
        Center,

        /// <summary>
        /// Eternal Battlegrounds (WvW) map type.
        /// </summary>
        EternalBattlegrounds = Center,

        /// <summary>
        /// Edge of the Mists map type.
        /// </summary>
        EdgeOfTheMists
    }
}
