using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a emote.
    /// </summary>
    public class Emote : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The emote id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The emote commands.
        /// </summary>
        public IReadOnlyList<string> Commands { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The items that unlock this emote.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItems { get; set; } = Array.Empty<int>();
    }
}
