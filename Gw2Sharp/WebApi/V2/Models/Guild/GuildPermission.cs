namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild permission.
    /// </summary>
    public class GuildPermission : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The guild permission id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The guild permission name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The guild permission description.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
