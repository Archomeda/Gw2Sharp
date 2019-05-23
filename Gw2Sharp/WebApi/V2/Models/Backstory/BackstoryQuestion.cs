using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a backstory question.
    /// </summary>
    public class BackstoryQuestion : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The backstory question id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The backstory question title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The backstory question description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The list of backstory question answer ids.
        /// Each element can be resolved against <see cref="IBackstoryClient.Answers"/>.
        /// </summary>
        public IReadOnlyList<string> Answers { get; set; } = new List<string>();

        /// <summary>
        /// The backstory question order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The list of races to which the backstory question applies to.
        /// If the backstory question applies to all races, this value is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        public IReadOnlyList<string>? Races { get; set; }

        /// <summary>
        /// The list of professions to which the backstory question applies to.
        /// If the backstory question applies to all professions, this value is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public IReadOnlyList<string>? Professions { get; set; }
    }
}
