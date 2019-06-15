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

        /// <summary>
        /// Gets the continents.
        /// </summary>
        IContinentsClient Continents { get; }

        /// <summary>
        /// Gets the create subtoken.
        /// </summary>
        ICreateSubtokenClient CreateSubtoken { get; }

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        ICurrenciesClient Currencies { get; }

        /// <summary>
        /// Gets the daily craftings.
        /// </summary>
        IDailyCraftingClient DailyCrafting { get; }

        /// <summary>
        /// Gets the dungeons.
        /// </summary>
        IDungeonsClient Dungeons { get; }

        /// <summary>
        /// Gets the emblems.
        /// </summary>
        IEmblemClient Emblem { get; }

        /// <summary>
        /// Gets the files.
        /// </summary>
        IFilesClient Files { get; }

        /// <summary>
        /// Gets the finishers.
        /// </summary>
        IFinishersClient Finishers { get; }

        /// <summary>
        /// Gets the gliders.
        /// </summary>
        IGlidersClient Gliders { get; }

        /// <summary>
        /// Gets the guild.
        /// </summary>
        IGuildClient Guild { get; }

        /// <summary>
        /// Gets the home.
        /// </summary>
        IHomeClient Home { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        IItemsClient Items { get; }

        /// <summary>
        /// Gets the itemstats.
        /// </summary>
        IItemstatsClient Itemstats { get; }

        /// <summary>
        /// Gets the legends.
        /// </summary>
        ILegendsClient Legends { get; }

        /// <summary>
        /// Gets the map chests.
        /// </summary>
        IMapChestsClient MapChests { get; }

        /// <summary>
        /// Gets the maps.
        /// </summary>
        IMapsClient Maps { get; }

        /// <summary>
        /// Gets the token info.
        /// </summary>
        ITokenInfoClient TokenInfo { get; }
    }
}
