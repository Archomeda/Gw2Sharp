namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the scores of a WvW match map.
    /// </summary>
    public class WvwMatchScoresMap : ApiV2BaseObject
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
        /// The map score distribution per team.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();
    }
}
