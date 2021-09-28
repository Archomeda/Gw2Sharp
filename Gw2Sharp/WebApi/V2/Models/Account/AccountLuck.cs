using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account luck.
    /// </summary>
    [Obsolete("Deprecated since 2021-09-28. Use Account.Progression instead. This will be removed from Gw2Sharp starting from version 2.0.")]
    public class AccountLuck
    {
        /// <summary>
        /// The luck id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The luck value.
        /// </summary>
        public int Value { get; set; }
    }
}
