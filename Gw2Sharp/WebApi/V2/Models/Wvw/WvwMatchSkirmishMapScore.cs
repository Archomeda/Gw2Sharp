namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw Skirmish map score.
    /// </summary>
    public class WvwMatchSkirmishMapScore : ApiV2BaseObject
    {
        /// <summary>
        /// The map type.
        /// </summary>
        public ApiEnum<WvwMapType> Type { get; set; } = new ApiEnum<WvwMapType>();

        /// <summary>
        /// Scores per team.
        /// </summary>
        public WvwMatchTeamValues Scores { get; set; } = new WvwMatchTeamValues();
    }
}
