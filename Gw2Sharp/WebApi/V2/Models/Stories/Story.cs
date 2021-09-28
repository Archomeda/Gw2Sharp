using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a story.
    /// </summary>
    public class Story : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The story id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The story season.
        /// Can be resolved against <see cref="IStoriesClient.Seasons"/>.
        /// </summary>
        public Guid Season { get; set; }

        /// <summary>
        /// The story name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The story description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The story timeline.
        /// </summary>
        public string Timeline { get; set; } = string.Empty;

        /// <summary>
        /// The story level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The races that have access to this story.
        /// If this story has no racial restriction, this value is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        public IReadOnlyList<string>? Races { get; set; }

        /// <summary>
        /// The story order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The story chapters.
        /// </summary>
        public IReadOnlyList<StoryChapter> Chapters { get; set; } = Array.Empty<StoryChapter>();

        /// <summary>
        /// The story flags.
        /// </summary>
        public ApiFlags<StoryFlag> Flags { get; set; } = new ApiFlags<StoryFlag>();
    }
}
