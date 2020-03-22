using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The PvP rating type.
    /// </summary>
    public enum PvpRatingType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// No type.
        /// </summary>
        None,

        /// <summary>
        /// Ranked.
        /// </summary>
        Ranked,

        /// <summary>
        /// Unranked.
        /// </summary>
        Unranked,

        /// <summary>
        /// 2v2 ranked.
        /// "2v2Ranked" in the API, but named differently in Gw2Sharp due to technical limitations.
        /// </summary>
        [EnumMember(Value = "2v2Ranked")]
        TwoVTwoRanked
    }
}
