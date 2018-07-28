using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for the client implementation of the Guild Wars 2 web API v2.
    /// </summary>
    public interface IGw2WebApiV2Client
    {
        /// <summary>
        /// Provides the client connection to make web requests.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Gets the account information.
        /// Requires scopes: account.
        /// </summary>
        IAccountClient Account { get; }

        /// <summary>
        /// Gets the achievements.
        /// </summary>
        IAchievementsClient Achievements { get; }

        /// <summary>
        /// Gets the backstory.
        /// </summary>
        IBackstoryClient Backstory { get; }

        /// <summary>
        /// Gets the build.
        /// </summary>
        IBuildClient Build { get; }

        /// <summary>
        /// Gets the cats.
        /// </summary>
        ICatsClient Cats { get; }

        /// <summary>
        /// Gets the characters.
        /// Requires scopes: account, characters.
        /// </summary>
        ICharactersClient Characters { get; }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        IColorsClient Colors { get; }

        /// <summary>
        /// Gets the commerce.
        /// </summary>
        ICommerceClient Commerce { get; }
    }
}
