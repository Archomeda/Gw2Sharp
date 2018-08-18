using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The guild log influence activity.
    /// </summary>
    public enum GuildLogInfluenceActivity
    {
        /// <summary>
        /// Unknown activity.
        /// </summary>
        Unknown,

        /// <summary>
        /// Gifted activity.
        /// </summary>
        Gifted,

        /// <summary>
        /// Daily login activity.
        /// </summary>
        [EnumMember(Value = "daily_login")]
        DailyLogin
    }
}
