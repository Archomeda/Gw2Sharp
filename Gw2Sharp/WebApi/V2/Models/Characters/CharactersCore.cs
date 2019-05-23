using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters core endpoint.
    /// </summary>
    public class CharactersCore : ApiV2BaseObject
    {
        /// <summary>
        /// The character name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The character's race.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        public string Race { get; set; } = string.Empty;

        /// <summary>
        /// The character's gender.
        /// </summary>
        public ApiEnum<Gender> Gender { get; set; } = new ApiEnum<Gender>();

        /// <summary>
        /// The character's profession.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// The character's level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The character's guild.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Guild"/>.
        /// </summary>
        public Guid Guild { get; set; }

        /// <summary>
        /// The character's total play time.
        /// </summary>
        public TimeSpan Age { get; set; }

        /// <summary>
        /// The last modification date for this data.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// The date the character was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The number of times the character has died.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// The character's current active title.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Title"/>.
        /// </summary>
        public int Title { get; set; }
    }
}
