using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a build template.
    /// </summary>
    public class BuildTemplate
    {
        /// <summary>
        /// The build template name.
        /// If the build template isn't set, this value is <see langword="null"/>.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The build template profession.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// If the build template isn't set, this value is <see langword="null"/>.
        /// </summary>
        public string? Profession { get; set; }

        /// <summary>
        /// The list of specializations.
        /// </summary>
        public IReadOnlyList<BuildTemplateSpecialization> Specializations { get; set; } = Array.Empty<BuildTemplateSpecialization>();

        /// <summary>
        /// The skills.
        /// </summary>
        public BuildTemplateSkills Skills { get; set; } = new BuildTemplateSkills();

        /// <summary>
        /// The aquatic skills.
        /// </summary>
        public BuildTemplateSkills AquaticSkills { get; set; } = new BuildTemplateSkills();

        /// <summary>
        /// The pet skills.
        /// If the profession is not a ranger, this value is <see langword="null"/>.
        /// </summary>
        public BuildTemplatePets Pets { get; set; } = new BuildTemplatePets();

        /// <summary>
        /// The list of revenant skills.
        /// If the profession is not a revenant, this value is <see langword="null"/>.
        /// If a legend is not selected in a specific slot, that element is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Legends"/>.
        /// </summary>
        public IReadOnlyList<string?>? Legends { get; set; }

        /// <summary>
        /// The list of aquatic revenant skills.
        /// If the profession is not a revenant, this value is <see langword="null"/>.
        /// If a legend is not selected in a specific slot, that element is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Legends"/>.
        /// </summary>
        public IReadOnlyList<string?>? AquaticLegends { get; set; }
    }
}
