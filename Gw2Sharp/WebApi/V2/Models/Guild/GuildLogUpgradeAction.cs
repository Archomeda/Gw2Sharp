using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The guild log upgrade action.
    /// </summary>
    public enum GuildLogUpgradeAction
    {
        /// <summary>
        /// Unknown action.
        /// </summary>
        Unknown,

        /// <summary>
        /// Queued action.
        /// </summary>
        Queued,

        /// <summary>
        /// Completed action.
        /// </summary>
        Completed,

        /// <summary>
        /// Cancelled action.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Sped up action.
        /// </summary>
        [EnumMember(Value = "sped_up")]
        SpedUp
    }
}
