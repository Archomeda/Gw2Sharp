using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The guild log stash operation.
    /// </summary>
    public enum GuildLogStashOperation
    {
        /// <summary>
        /// Unknown operation.
        /// </summary>
        Unknown,

        /// <summary>
        /// Deposit operation.
        /// </summary>
        Deposit,

        /// <summary>
        /// Withdraw operation.
        /// </summary>
        Withdraw,

        /// <summary>
        /// Move operation.
        /// </summary>
        Move
    }
}
