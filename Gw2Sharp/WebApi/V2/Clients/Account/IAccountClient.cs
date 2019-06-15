using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account endpoint.
    /// </summary>
    public interface IAccountClient :
        IAuthenticatedClient<Account>,
        IBlobClient<Account>
    {
        /// <summary>
        /// Gets the achievement progression.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountAchievementsClient Achievements { get; }

        /// <summary>
        /// Gets the bank.
        /// Requires scopes: account, inventories.
        /// </summary>
        IAccountBankClient Bank { get; }

        /// <summary>
        /// Gets the daily crafting progression.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.DailyCrafting"/>.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountDailyCraftingClient DailyCrafting { get; }

        /// <summary>
        /// Gets the daily completed dungeons.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Dungeons"/> as path ids.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountDungeonsClient Dungeons { get; }

        /// <summary>
        /// Gets the unlocked dyes.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountDyesClient Dyes { get; }

        /// <summary>
        /// Gets the unlocked finishers.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountFinishersClient Finishers { get; }

        /// <summary>
        /// Gets the unlocked glider skins.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Gliders"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountGlidersClient Gliders { get; }

        /// <summary>
        /// Gets the home.
        /// </summary>
        IAccountHomeClient Home { get; }

        /// <summary>
        /// Gets the bank.
        /// Requires scopes: account, inventories.
        /// </summary>
        IAccountInventoryClient Inventory { get; }

        /// <summary>
        /// Gets the luck progression.
        /// Requires scores: account, progression, unlocks.
        /// </summary>
        IAccountLuckClient Luck { get; }

        /// <summary>
        /// Gets the unlocked mail carriers.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.MailCarriers"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountMailCarriersClient MailCarriers { get; }

        /// <summary>
        /// Gets the map chests progression.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.MapChests"/>.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountMapChestsClient MapChests { get; }

        /// <summary>
        /// Gets the mastery progression.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountMasteriesClient Masteries { get; }

        /// <summary>
        /// Gets the masteries.
        /// </summary>
        IAccountMasteryClient Mastery { get; }

        /// <summary>
        /// Gets the material storage.
        /// Requires scopes: account, inventories.
        /// </summary>
        IAccountMaterialsClient Materials { get; }

        /// <summary>
        /// Gets the unlocked minis.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Minis"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountMinisClient Minis { get; }

        /// <summary>
        /// Gets the mounts.
        /// </summary>
        IAccountMountsClient Mounts { get; }

        /// <summary>
        /// Gets the novelties.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Novelties"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountNoveltiesClient Novelties { get; }

        /// <summary>
        /// Gets the unlocked outfits.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Outfits"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountOutfitsClient Outfits { get; }

        /// <summary>
        /// Gets the PvP.
        /// </summary>
        IAccountPvpClient Pvp { get; }

        /// <summary>
        /// Gets the weekly completed dungeons.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountRaidsClient Raids { get; }

        /// <summary>
        /// Gets the unlocked recipes.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountRecipesClient Recipes { get; }

        /// <summary>
        /// Gets the unlocked skins.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountSkinsClient Skins { get; }

        /// <summary>
        /// Gets the unlocked titles.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Titles"/>.
        /// Requires scopes: account, unlocks.
        /// </summary>
        IAccountTitlesClient Titles { get; }

        /// <summary>
        /// Gets the wallet.
        /// Requires scopes: account, wallet.
        /// </summary>
        IAccountWalletClient Wallet { get; }

        /// <summary>
        /// Gets the daily world bosses progression.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.WorldBosses"/>.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountWorldBossesClient WorldBosses { get; }
    }
}
