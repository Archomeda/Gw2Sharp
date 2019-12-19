namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account build storage slot.
    /// </summary>
    public class AccountBuildStorageSlot : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The build storage slot id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The build.
        /// </summary>
        public BuildTemplate Build { get; set; } = new BuildTemplate();
    }
}
