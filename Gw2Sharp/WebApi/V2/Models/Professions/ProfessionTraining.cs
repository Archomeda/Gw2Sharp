using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the profession training.
    /// </summary>
    public class ProfessionTraining
    {
        /// <summary>
        /// The profession training id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The profession training name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The profession training category.
        /// </summary>
        public ApiEnum<ProfessionTrainingCategory> Category { get; set; } = new ApiEnum<ProfessionTrainingCategory>();

        /// <summary>
        /// The profession training track steps.
        /// </summary>
        public IReadOnlyList<ProfessionTrainingTrackStep> Track { get; set; } = Array.Empty<ProfessionTrainingTrackStep>();
    }
}
