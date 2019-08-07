namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a raid wing event.
    /// </summary>
    public class RaidWingEvent
    {
        /// <summary>
        /// The raid wing event id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The raid wing event type.
        /// </summary>
        public ApiEnum<RaidWingEventType> Type { get; set; } = new ApiEnum<RaidWingEventType>();
    }
}
