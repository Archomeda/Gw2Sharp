namespace Gw2Sharp
{
    /// <summary>
    /// The PvP season division flag.
    /// </summary>
    public enum PvpSeasonDivisionFlag
    {
        /// <summary>
        /// Unknown flag.
        /// </summary>
        Unknown,

        /// <summary>
        /// In this division, players can lose points.
        /// </summary>
        CanLosePoints,

        /// <summary>
        /// In this division, players can lose tiers.
        /// </summary>
        CanLoseTiers,

        /// <summary>
        /// This division is repeatable.
        /// </summary>
        Repeatable
    }
}
