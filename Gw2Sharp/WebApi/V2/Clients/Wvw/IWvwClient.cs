namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 WvW endpoint.
    /// </summary>
    public interface IWvwClient
    {
        /// <summary>
        /// Gets the WvW abilities.
        /// </summary>
        IWvwAbilitiesClient Abilities { get; }

        /// <summary>
        /// Gets the WvW matches.
        /// </summary>
        IWvwMatchesClient Matches { get; }

        /// <summary>
        /// Gets the WvW objectives.
        /// </summary>
        IWvwObjectivesClient Objectives { get; }

        /// <summary>
        /// Gets the WvW ranks.
        /// </summary>
        IWvwRanksClient Ranks { get; }

        /// <summary>
        /// Gets the WvW upgrades.
        /// </summary>
        IWvwUpgradesClient Upgrades { get; }
    }
}
