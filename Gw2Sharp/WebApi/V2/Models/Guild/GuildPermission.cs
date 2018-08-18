namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a guild permission.
    /// </summary>
    public class GuildPermission : IIdentifiable<string>
    {
        /// <summary>
        /// The guild permission id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The guild permission name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The guild permission description.
        /// </summary>
        public string Description { get; set; }
    }
}
