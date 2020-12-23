namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the stats of a WvW match map.
    /// </summary>
    public class WvwMatchStatsMap : ApiV2BaseObject
    {
        /// <summary>
        /// The map id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The map type.
        /// </summary>
        public ApiEnum<WvwMapType> Type { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// The map kill distribution per team.
        /// </summary>
        public WvwMatchTeamValues Kills { get; set; } = new WvwMatchTeamValues();

        /// <summary>
        /// The map death distribution per team.
        /// </summary>
        public WvwMatchTeamValues Deaths { get; set; } = new WvwMatchTeamValues();
    }
}
