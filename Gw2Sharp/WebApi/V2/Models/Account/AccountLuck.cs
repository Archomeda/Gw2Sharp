using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Deprecated. Use <see cref="AccountProgression"/> instead.
    /// </summary>
    [Obsolete("This has been deprecated since version 2.0. Use Account.Progression instead.", true)]
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
