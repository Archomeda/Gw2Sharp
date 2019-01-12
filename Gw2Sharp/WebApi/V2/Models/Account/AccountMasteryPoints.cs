using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the object returned from the account mastery points endpoint.
    /// </summary>
    public class AccountMasteryPoints
    {
        /// <summary>
        /// The mastery points totals separated by region.
        /// </summary>
        public IReadOnlyList<AccountMasteryPointsRegion> Totals { get; set; } = new List<AccountMasteryPointsRegion>();

        /// <summary>
        /// The ids of the unlocked mastery points.
        /// </summary>
        public IReadOnlyList<int> Unlocked { get; set; } = new List<int>();
    }
}
