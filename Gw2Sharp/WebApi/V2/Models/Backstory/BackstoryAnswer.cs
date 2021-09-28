using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a backstory answer.
    /// </summary>
    public class BackstoryAnswer : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The backstory answer id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The backstory answer title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The backstory answer description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The backstory answer journal entry.
        /// </summary>
        public string Journal { get; set; } = string.Empty;

        /// <summary>
        /// The backstory answer question id.
        /// Can be resolved against <see cref="IBackstoryClient.Questions"/>.
        /// </summary>
        public int Question { get; set; }

        /// <summary>
        /// The list of races to which the backstory answer applies to.
        /// If the backstory answer applies to all races, this value is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        public IReadOnlyList<string>? Races { get; set; }

        /// <summary>
        /// The list of professions to which the backstory answer applies to.
        /// If the backstory answer applies to all professions, this value is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public IReadOnlyList<string>? Professions { get; set; }
    }
}
