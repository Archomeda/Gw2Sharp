using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a legend.
    /// </summary>
    public class Legend : IIdentifiable<string>
    {
        /// <summary>
        /// The legend id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The legend swap skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Swap { get; set; }

        /// <summary>
        /// The legend heal skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Heal { get; set; }

        /// <summary>
        /// The legend elite skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Elite { get; set; }

        /// <summary>
        /// The list of legend utility skill ids.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public IReadOnlyList<int> Utilities { get; set; } = new List<int>();
    }
}
