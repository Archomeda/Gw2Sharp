using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character.
    /// </summary>
    public class Character : IIdentifiable<string>
    {
        string IIdentifiable<string>.Id
        {
            get => this.Name;
            set => this.Name = value;
        }

        /// <summary>
        /// The character name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The character's race.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// The character's gender.
        /// </summary>
        public ApiEnum<Gender> Gender { get; set; }

        /// <summary>
        /// The character flags.
        /// </summary>
        public IReadOnlyList<ApiEnum<CharacterFlag>> Flags { get; set; }

        /// <summary>
        /// The character's profession.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public string Profession { get; set; }

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
        /// The date the character was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The number of times the character has died.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// The list of the character crafting disciplines.
        /// </summary>
        public IReadOnlyList<CharacterCraftingDiscipline> Crafting { get; set; }

        /// <summary>
        /// The character's current active title.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Title"/>.
        /// </summary>
        public int Title { get; set; }

        /// <summary>
        /// The character backstory answers.
        /// Each element can be resolved against <see cref="IBackstoryClient.Answers"/>.
        /// </summary>
        public IReadOnlyList<string> Backstory { get; set; }

        /// <summary>
        /// The character's WvW abilities.
        /// Additionally requires scopes: progression.
        /// </summary>
        public IReadOnlyList<CharacterWvwAbility> WvwAbilities { get; set; }

        /// <summary>
        /// The character specializations.
        /// Additionally requires scopes: builds.
        /// </summary>
        public CharacterSpecializations Specializations { get; set; }

        /// <summary>
        /// The character skills.
        /// Additionally requires scopes: builds.
        /// </summary>
        public CharacterSkills Skills { get; set; }

        /// <summary>
        /// The list of the character equipment.
        /// Additionally requires scopes: builds and/or inventories.
        /// </summary>
        public IReadOnlyList<CharacterEquipmentItem> Equipment { get; set; }

        /// <summary>
        /// The list of learned recipes.
        /// Additionally requires scopes: inventories.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public IReadOnlyList<int> Recipes { get; set; }

        /// <summary>
        /// The character PvP equipment.
        /// Additionally requires scopes: builds.
        /// </summary>
        public CharacterEquipmentPvp EquipmentPvp { get; set; }

        /// <summary>
        /// The list of character trainings.
        /// Additionally requires scopes: builds.
        /// </summary>
        public IReadOnlyList<CharacterTraining> Training { get; set; }

        /// <summary>
        /// The list of the character inventory bags.
        /// Additionally requires scopes: inventories.
        /// </summary>
        public IReadOnlyList<CharacterInventoryBag> Bags { get; set; }
    }
}
