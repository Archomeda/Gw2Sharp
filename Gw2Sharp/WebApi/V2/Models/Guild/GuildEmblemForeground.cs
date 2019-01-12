using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild emblem foreground.
    /// </summary>
    public class GuildEmblemForeground
    {
        /// <summary>
        /// The emblem id.
        /// Can be resolved against <see cref="IEmblemClient.Foregrounds"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The colors.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        public IReadOnlyList<int> Colors { get; set; } = new List<int>();
    }
}
