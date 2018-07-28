namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character training.
    /// </summary>
    public class CharacterTraining : IIdentifiable<int>
    {
        /// <summary>
        /// The training id.
        /// Can be resolved against <see cref="IProfessions.Trainings"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The amount of hero points spent for this training.
        /// </summary>
        public int Spent { get; set; }

        /// <summary>
        /// Whether the training is fully completed.
        /// </summary>
        public bool Done { get; set; }
    }
}
