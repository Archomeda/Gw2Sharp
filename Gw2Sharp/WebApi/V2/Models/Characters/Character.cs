using System;
using System.Collections.Generic;
using System.Linq;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character.
    /// </summary>
    public class Character : ApiV2BaseObject, IIdentifiable<string>
    {
#pragma warning disable CA1033 // Interface methods should be callable by child types
        string IIdentifiable<string>.Id
        {
            get => this.Name;
            set => this.Name = value;
        }
#pragma warning restore CA1033 // Interface methods should be callable by child types

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
        /// The character flags.
        /// </summary>
        public ApiFlags<CharacterFlag> Flags { get; set; } = new ApiFlags<CharacterFlag>();

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
        /// If the character is not representing a guild, this value is <see langword="null"/>.
        /// </summary>
        public Guid? Guild { get; set; }

        /// <summary>
        /// The character's total play time.
        /// </summary>
        public TimeSpan Age { get; set; }

        /// <summary>
        /// The last modification date for this data.
        /// </summary>
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// The date the character was created.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The number of times the character has died.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// The list of the character crafting disciplines.
        /// </summary>
        public IReadOnlyList<CharacterCraftingDiscipline> Crafting { get; set; } = Array.Empty<CharacterCraftingDiscipline>();

        /// <summary>
        /// The character's current active title.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Titles"/>.
        /// </summary>
        public int Title { get; set; }

        /// <summary>
        /// The character backstory answers.
        /// Each element can be resolved against <see cref="IBackstoryClient.Answers"/>.
        /// </summary>
        public IReadOnlyList<string> Backstory { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The character's WvW abilities.
        /// Additionally requires scopes: progression.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterWvwAbility>? WvwAbilities { get; set; }

        /// <summary>
        /// The number of build tabs that this character has unlocked.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public int? BuildTabsUnlocked { get; set; }

        /// <summary>
        /// The current active build tab index. To be used as index in <see cref="BuildTabs"/>.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public int? ActiveBuildTab { get; set; }

        /// <summary>
        /// The list of character build tabs.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterBuildTabSlot>? BuildTabs { get; set; }

        /// <summary>
        /// The list of the character equipment.
        /// Additionally requires scopes: builds and/or inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterEquipmentItem>? Equipment { get; set; }

        /// <summary>
        /// The number of equipment tabs that this character has unlocked.
        /// Additionally requires scopes: builds and/or inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public int? EquipmentTabsUnlocked { get; set; }

        /// <summary>
        /// The current active equipment tab index. To be used as index in <see cref="EquipmentTabs"/>.
        /// Additionally requires scopes: builds and/or inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public int? ActiveEquipmentTab { get; set; }

        /// <summary>
        /// The list of the character equipment tabs.
        /// Additionally requires scopes: builds and/or inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterEquipmentTabSlot>? EquipmentTabs { get; set; }

        /// <summary>
        /// The list of learned recipes.
        /// Additionally requires scopes: inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public IReadOnlyList<int>? Recipes { get; set; }

        /// <summary>
        /// The character PvP equipment.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        [Obsolete("Deprecated since schema version 2021-04-06T21:00:00.000Z. Use EquipmentTabs[i].EquipmentPvp instead. This will be removed from Gw2Sharp starting from version 2.0.")]
        public CharacterEquipmentPvp? EquipmentPvp =>
            // Instead of using the old schema version to pull this information while also supporting the latest schema,
            // we emulate the migration roll-forward ability ourselves by grabbing the current active tab information.
            this.EquipmentTabs?.FirstOrDefault(x => x.Tab == this.ActiveEquipmentTab)?.EquipmentPvp;

        /// <summary>
        /// The list of character trainings.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterTraining>? Training { get; set; }

        /// <summary>
        /// The list of the character inventory bags.
        /// Additionally requires scopes: inventories.
        /// If the required scopes are not met, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<CharacterInventoryBag>? Bags { get; set; }
    }
}
