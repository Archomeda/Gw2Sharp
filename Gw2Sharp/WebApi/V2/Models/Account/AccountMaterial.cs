namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account material.
    /// </summary>
    public class AccountMaterial : IIdentifiable<int>
    {
        /// <summary>
        /// The material item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The material category.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Materials"/>.
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// The material binding.
        /// If the material is not bound, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<ItemBinding>? Binding { get; set; }

        /// <summary>
        /// The stored amount of this material.
        /// </summary>
        public int Count { get; set; }
    }
}
