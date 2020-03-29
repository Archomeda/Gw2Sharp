using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the overridden dye slots of an armor skin.
    /// </summary>
    public class SkinArmorDetailsDyeSlotsOverrides
    {
        /// <summary>
        /// The overridden dye slots for male asura.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("AsuraMale")]
        public IReadOnlyList<SkinDyeSlot?>? AsuraMale { get; set; }

        /// <summary>
        /// The overridden dye slots for female asura.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("AsuraFemale")]
        public IReadOnlyList<SkinDyeSlot?>? AsuraFemale { get; set; }

        /// <summary>
        /// The overridden dye slots for male charr.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("CharrMale")]
        public IReadOnlyList<SkinDyeSlot?>? CharrMale { get; set; }

        /// <summary>
        /// The overridden dye slots for female charr.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("CharrFemale")]
        public IReadOnlyList<SkinDyeSlot?>? CharrFemale { get; set; }

        /// <summary>
        /// The overridden dye slots for male humans.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("HumanMale")]
        public IReadOnlyList<SkinDyeSlot?>? HumanMale { get; set; }

        /// <summary>
        /// The overridden dye slots for female humans.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("HumanFemale")]
        public IReadOnlyList<SkinDyeSlot?>? HumanFemale { get; set; }

        /// <summary>
        /// The overridden dye slots for male norn.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("NornMale")]
        public IReadOnlyList<SkinDyeSlot?>? NornMale { get; set; }

        /// <summary>
        /// The overridden dye slots for female norn.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("NornFemale")]
        public IReadOnlyList<SkinDyeSlot?>? NornFemale { get; set; }

        /// <summary>
        /// The overridden dye slots for male sylvari.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("SylvariMale")]
        public IReadOnlyList<SkinDyeSlot?>? SylvariMale { get; set; }

        /// <summary>
        /// The overridden dye slots for female sylvari.
        /// If no overrides have been defined, this value is <c>null</c>.
        /// If a dye slot isn't available, that element is <c>null</c>.
        /// </summary>
        [JsonPropertyName("SylvariFemale")]
        public IReadOnlyList<SkinDyeSlot?>? SylvariFemale { get; set; }
    }
}
