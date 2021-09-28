namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a sub skill.
    /// </summary>
    public class SkillSubSkill : IIdentifiable<int>
    {
        /// <summary>
        /// The sub skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The sub skill attunement.
        /// If the sub skill doesn't have an attunement, this value is <see langword="null"/>.
        /// </summary>
        public ApiEnum<Attunement>? Attunement { get; set; }

        /// <summary>
        /// The sub skill form.
        /// If the sub skill doesn't have a form, this value is <see langword="null"/>.
        /// </summary>
        public ApiEnum<TransformationForm>? Form { get; set; }
    }
}
