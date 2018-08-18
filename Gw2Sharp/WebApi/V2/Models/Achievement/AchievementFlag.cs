namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The achievement flag.
    /// </summary>
    public enum AchievementFlag
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// The achievement will only progress in PvP or WvW.
        /// </summary>
        Pvp,

        /// <summary>
        /// The achievement is a meta achievement.
        /// </summary>
        CategoryDisplay,

        /// <summary>
        /// The achievement is shown as the first achievement in the list.
        /// </summary>
        MoveToTop,

        /// <summary>
        /// The achievement does not appear in the "Nearly completed achievements" list.
        /// </summary>
        IgnoreNearlyComplete,

        /// <summary>
        /// The achievement is repeatable.
        /// </summary>
        Repeatable,

        /// <summary>
        /// The achievement is hidden until unlocked.
        /// </summary>
        Hidden,

        /// <summary>
        /// The achievement requires to be unlocked first.
        /// </summary>
        RequiresUnlock,

        /// <summary>
        /// The achievement is repaired on login.
        /// </summary>
        RepairOnLogin,

        /// <summary>
        /// The achievement is a daily achievement.
        /// </summary>
        Daily,

        /// <summary>
        /// The achievement is a weekly achievement.
        /// </summary>
        Weekly,

        /// <summary>
        /// The achievement is a monthly achievement.
        /// </summary>
        Monthly,

        /// <summary>
        /// The achievement progression is permanent and will not reset.
        /// </summary>
        Permanent
    }
}
