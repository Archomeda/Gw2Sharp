namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 wvw endpoint.
    /// </summary>
    public interface IWvwClient
    {
        /// <summary>
        /// Gets the Wvw Abilities
        /// </summary>
        IWvwAbilitiesClient Abilities { get; }

        /// <summary>
        /// Gets the Wvw Matches
        /// </summary>
        IWvwMatchesClient Matches { get; }

        /// <summary>
        /// Gets the Wvw Objectives.
        /// </summary>
        IWvwObjectivesClient Objectives { get; }

        /// <summary>
        /// Gets the Wvw Ranks.
        /// </summary>
        IWvwRanksClient Ranks { get; }

        /// <summary>
        /// Gets the Wvw Upgrades.
        /// </summary>
        IWvwUpgradesClient Upgrades { get; }
    }
}
