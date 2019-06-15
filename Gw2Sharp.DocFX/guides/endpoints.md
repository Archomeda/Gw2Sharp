---
uid: Guides.Endpoints
title: Supported endpoints
---

# Supported endpoints
Gw2Sharp is not finished yet, and development is being done whenever I have spare time.
For your convenience, the following list gives an overview of the endpoints that are already available in this library:

 Icon | Description
------|-------------
✔️   | Implemented
❌   | Not implemented yet, but is available on API
❌✨ | Not implemented yet, recent addition to the API
✖️   | Missing on API
➡️   | Endpoint has moved, will deprecate in the future
🔑   | Endpoint with authentication
🌐   | Endpoint with locale support
📆   | Endpoint with `Last-Modified` support
📄   | Endpoint with pagination support
📚   | Endpoint with bulk support
📦   | Endpoint with bulk all support

 Endpoint | Availability | Class
----------|----------------------|-------
 /v2/account | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account`](../api/Gw2Sharp.WebApi.V2.Clients.AccountClient.html)
 /v2/account/achievements | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Achievements`](../api/Gw2Sharp.WebApi.V2.Clients.AccountAchievementsClient.html)
 /v2/account/bank | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Bank`](../api/Gw2Sharp.WebApi.V2.Clients.AccountBankClient.html)
 /v2/account/dailycrafting | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.DailyCrafting`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDailyCraftingClient.html)
 /v2/account/dungeons | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Dungeons`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDungeonsClient.html)
 /v2/account/dyes | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Dyes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDyesClient.html)
 /v2/account/finishers | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Finishers`](../api/Gw2Sharp.WebApi.V2.Clients.AccountFinishersClient.html)
 /v2/account/gliders | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Gliders`](../api/Gw2Sharp.WebApi.V2.Clients.AccountGlidersClient.html)
 /v2/account/home | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Home`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeClient.html)
 /v2/account/home/cats | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Home.Cats`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeCatsClient.html)
 /v2/account/home/nodes | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Home.Nodes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeNodesClient.html)
 /v2/account/inventory | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Inventory`](../api/Gw2Sharp.WebApi.V2.Clients.AccountInventoryClient.html)
 /v2/account/luck | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Luck`](../api/Gw2Sharp.WebApi.V2.Clients.AccountLuckClient.html)
 ~~/v2/account/mail~~ | ✖️ |
 /v2/account/mailcarriers | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.MailCarriers`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMailCarriersClient.html)
 /v2/account/mapchests | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.MapChests`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMapChestsClient.html)
 /v2/account/masteries | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Masteries`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMasteriesClient.html)
 /v2/account/mastery/points | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Mastery.Points`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMasteryPointsClient.html)
 /v2/account/materials | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Materials`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMaterialsClient.html)
 /v2/account/minis | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Minis`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMinisClient.html)
 /v2/account/mounts | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Mounts`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsClient.html)
 /v2/account/mounts/skins | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Mounts.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsSkinsClient.html)
 /v2/account/mounts/types | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Mounts.Types`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsTypesClient.html)
 /v2/account/novelties | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Novelties.Types`](../api/Gw2Sharp.WebApi.V2.Clients.AccountNoveltiesClient.html)
 /v2/account/outfits | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Outfits`](../api/Gw2Sharp.WebApi.V2.Clients.AccountOutfitsClient.html)
 /v2/account/pvp/heroes | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Pvp.Heroes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountPvpHeroesClient.html)
 /v2/account/raids | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Raids`](../api/Gw2Sharp.WebApi.V2.Clients.AccountRaidsClient.html)
 /v2/account/recipes | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Recipes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountRecipesClient.html)
 /v2/account/skins | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.AccountSkinsClient.html)
 /v2/account/titles | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Titles`](../api/Gw2Sharp.WebApi.V2.Clients.AccountTitlesClient.html)
 /v2/account/wallet | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.Wallet`](../api/Gw2Sharp.WebApi.V2.Clients.AccountWalletClient.html)
 /v2/account/worldbosses | ✔️🔑📆 | [`Gw2WebApiClient.V2.Account.WorldBosses`](../api/Gw2Sharp.WebApi.V2.Clients.AccountWorldBossesClient.html)
 /v2/achievements | ✔️🌐📄📚 | [`Gw2WebApiClient.V2.Achievements`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsClient.html)
 /v2/achievements/categories | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Achievements.Categories`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsCategoriesClient.html)
 /v2/achievements/daily | ✔️ | [`Gw2WebApiClient.V2.Achievements.Daily`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsDailyClient.html)
 /v2/achievements/daily/tomorrow | ✔️ | [`Gw2WebApiClient.V2.Achievements.Daily.Tomorrow`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsDailyTomorrowClient.html)
 /v2/achievements/groups | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Achievements.Groups`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsGroupsClient.html)
 ~~/v2/adventures~~ | ✖️ |
 ~~/v2/adventures/`:id`/leaderboards~~ | ✖️ |
 ~~/v2/adventures/`:id`/leaderboards/:board/:region~~ | ✖️ |
 /v2/backstory/answers | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Backstory.Answers`](../api/Gw2Sharp.WebApi.V2.Clients.BackstoryAnswersClient.html)
 /v2/backstory/questions | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Backstory.Questions`](../api/Gw2Sharp.WebApi.V2.Clients.BackstoryQuestionsClient.html)
 /v2/build | ✔️ | [`Gw2WebApiClient.V2.Build`](../api/Gw2Sharp.WebApi.V2.Clients.BuildClient.html)
 /v2/characters | ✔️🔑📆📄📚📦 | [`Gw2WebApiClient.V2.Characters`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersClient.html)
 /v2/characters/`:id`/backstory | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Backstory`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdBackstoryClient.html)
 /v2/characters/`:id`/core | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Core`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdCoreClient.html)
 /v2/characters/`:id`/crafting | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Crafting`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdCraftingClient.html)
 ~~/v2/characters/`:id`/dungeons~~ | ✖️ |
 /v2/characters/`:id`/equipment | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Equipment`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdEquipmentClient.html)
 /v2/characters/`:id`/heropoints | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].HeroPoints`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdHeroPointsClient.html)
 /v2/characters/`:id`/inventory | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Inventory`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdInventoryClient.html)
 /v2/characters/`:id`/quests | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Quests`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdQuestsClient.html)
 /v2/characters/`:id`/recipes | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Recipes`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdRecipesClient.html)
 /v2/characters/`:id`/sab | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Sab`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdSabClient.html)
 /v2/characters/`:id`/skills | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Skills`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdSkillsClient.html)
 /v2/characters/`:id`/specializations | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Specializations`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdSpecializationsClient.html)
 /v2/characters/`:id`/training | ✔️🔑📆 | [`Gw2WebApiClient.V2.Characters[id].Training`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdTrainingClient.html)
 /v2/colors | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Colors`](../api/Gw2Sharp.WebApi.V2.Clients.ColorsClient.html)
 /v2/commerce/delivery | ✔️🔑 | [`Gw2WebApiClient.V2.Commerce.Delivery`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceDeliveryClient.html)
 /v2/commerce/exchange | ✔️ | [`Gw2WebApiClient.V2.Commerce.Exchange`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeClient.html)
 /v2/commerce/exchange/coins | ✔️ | [`Gw2WebApiClient.V2.Commerce.Exchange.Coins`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeCoinsClient.html)
 /v2/commerce/exchange/gems | ✔️ | [`Gw2WebApiClient.V2.Commerce.Exchange.Gems`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeGemsClient.html)
 /v2/commerce/listings | ✔️📄📚 | [`Gw2WebApiClient.V2.Commerce.Listings`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceListingsClient.html)
 /v2/commerce/prices | ✔️📄📚 | [`Gw2WebApiClient.V2.Commerce.Prices`](../api/Gw2Sharp.WebApi.V2.Clients.CommercePricesClient.html)
 /v2/commerce/transactions  | ✔️🔑 | [`Gw2WebApiClient.V2.Commerce.Transactions`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsClient.html)
 /v2/commerce/transactions/current  | ✔️🔑 | [`Gw2WebApiClient.V2.Commerce.Transactions.Current`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentClient.html)
 /v2/commerce/transactions/current/buys  | ✔️🔑📄 | [`Gw2WebApiClient.V2.Commerce.Transactions.Current.Buys`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentBuysClient.html)
 /v2/commerce/transactions/current/sells  | ✔️🔑📄 | [`Gw2WebApiClient.V2.Commerce.Transactions.Current.Sells`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentSellsClient.html)
 /v2/commerce/transactions/history  | ✔️🔑 | [`Gw2WebApiClient.V2.Commerce.Transactions.History`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistoryClient.html)
 /v2/commerce/transactions/history/buys  | ✔️🔑📄 | [`Gw2WebApiClient.V2.Commerce.Transactions.History.Buys`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistoryBuysClient.html)
 /v2/commerce/transactions/history/sells  | ✔️🔑📄 | [`Gw2WebApiClient.V2.Commerce.Transactions.History.Sells`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistorySellsClient.html)
 /v2/continents  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsClient.html)
 /v2/continents/`:continent`/<br>floors  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>pois  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Pois`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsPoisClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>sectors  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Sectors`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsSectorsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>tasks  | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Tasks`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsTasksClient.html)
 /v2/createsubtoken | ✔️🔑 | [`Gw2WebApiClient.V2.CreateSubtoken`](../api/Gw2Sharp.WebApi.V2.Clients.CreateSubtokenClient.html)
 /v2/currencies | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Currencies`](../api/Gw2Sharp.WebApi.V2.Clients.CurrenciesClient.html)
 /v2/dailycrafting | ✔️📄📚📦 | [`Gw2WebApiClient.V2.DailyCrafting`](../api/Gw2Sharp.WebApi.V2.Clients.DailyCraftingClient.html)
 /v2/dungeons | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Dungeons`](../api/Gw2Sharp.WebApi.V2.Clients.DungeonsClient.html)
 /v2/emblem | ✔️ | [`Gw2WebApiClient.V2.Emblem`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemClient.html)
 /v2/emblem/backgrounds | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Emblem.Backgrounds`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemBackgroundsClient.html)
 /v2/emblem/foregrounds | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Emblem.Foregrounds`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemForegroundsClient.html)
 ~~/v2/events~~ | ✖️ |
 ~~/v2/events-state~~ | ✖️ |
 /v2/files | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Files`](../api/Gw2Sharp.WebApi.V2.Clients.FilesClient.html)
 /v2/finishers | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Finishers`](../api/Gw2Sharp.WebApi.V2.Clients.FinishersClient.html)
 ~~/v2/gemstore/catalog~~ | ✖️ |
 /v2/gliders | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Gliders`](../api/Gw2Sharp.WebApi.V2.Clients.GlidersClient.html)
 /v2/guild/`:id` | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id]`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdClient.html)
 /v2/guild/`:id`/log | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Log`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdClient.html)
 /v2/guild/`:id`/members | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Members`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdMembersClient.html)
 /v2/guild/`:id`/ranks | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Ranks`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdRanksClient.html)
 /v2/guild/`:id`/stash | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Stash`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdStashClient.html)
 /v2/guild/`:id`/storage | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Storage`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdStorageClient.html)
 /v2/guild/`:id`/teams | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Teams`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdTeamsClient.html)
 /v2/guild/`:id`/treasury | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Treasury`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdTreasuryClient.html)
 /v2/guild/`:id`/upgrades | ✔️🔑 | [`Gw2WebApiClient.V2.Guild[id].Upgrades`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdUpgradesClient.html)
 /v2/guild/permissions | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Guild.Permissions`](../api/Gw2Sharp.WebApi.V2.Clients.GuildPermissionsClient.html)
 /v2/guild/search | ✔️ | [`Gw2WebApiClient.V2.Guild.Search`](../api/Gw2Sharp.WebApi.V2.Clients.GuildSearchClient.html)
 /v2/guild/upgrades | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Guild.Upgrades`](../api/Gw2Sharp.WebApi.V2.Clients.GuildUpgradesClient.html)
 /v2/home | ✔️ | [`Gw2WebApiClient.V2.Home`](../api/Gw2Sharp.WebApi.V2.Clients.HomeClient.html)
 /v2/home/cats | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Home.Cats`](../api/Gw2Sharp.WebApi.V2.Clients.HomeCatsClient.html)
 /v2/home/nodes | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Home.Nodes`](../api/Gw2Sharp.WebApi.V2.Clients.HomeNodesClient.html)
 /v2/items | ✔️🌐📄📚 | [`Gw2WebApiClient.V2.Items`](../api/Gw2Sharp.WebApi.V2.Clients.ItemsClient.html)
 /v2/itemstats | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Itemstats`](../api/Gw2Sharp.WebApi.V2.Clients.ItemstatsClient.html)
 /v2/legends | ✔️📄📚📦 | [`Gw2WebApiClient.V2.Legends`](../api/Gw2Sharp.WebApi.V2.Clients.LegendsClient.html)
 /v2/mailcarriers | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.MailCarriers`](../api/Gw2Sharp.WebApi.V2.Clients.MailCarriersClient.html)
 /v2/mapchests | ✔️📄📚📦 | [`Gw2WebApiClient.V2.MapChests`](../api/Gw2Sharp.WebApi.V2.Clients.MapChestsClient.html)
 /v2/maps | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Maps`](../api/Gw2Sharp.WebApi.V2.Clients.MapsClient.html)
 /v2/masteries | ❌ |
 /v2/materials | ✔️🌐📄📚📦 | [`Gw2WebApiClient.V2.Materials`](../api/Gw2Sharp.WebApi.V2.Clients.MaterialsClient.html)
 /v2/minis | ❌ |
 /v2/mounts | ❌✨ |
 /v2/mounts/skins | ❌✨ |
 /v2/mounts/types | ❌✨ |
 /v2/novelties | ❌✨ |
 /v2/outfits | ❌ |
 /v2/pets | ❌ |
 /v2/professions | ❌ |
 /v2/pvp | ❌ |
 /v2/pvp/amulets | ❌ |
 /v2/pvp/games | ❌ |
 /v2/pvp/heroes | ❌ |
 ~~/v2/pvp/rewardtracks~~ | ✖️ |
 ~~/v2/pvp/runes~~ | ✖️ |
 /v2/pvp/seasons | ❌ |
 /v2/pvp/seasons/`:id`/leaderboards | ❌ |
 /v2/pvp/seasons/`:id`/leaderboards/`:board`/`:region` | ❌ |
 ~~/v2/pvp/sigils~~ | ✖️ |
 /v2/pvp/standings | ❌ |
 /v2/pvp/stats | ❌ |
 /v2/quaggans | ❌ |
 /v2/quests | ❌✨ |
 /v2/races | ❌ |
 /v2/raids | ❌ |
 /v2/recipes | ❌ |
 /v2/recipes/search | ❌ |
 /v2/skills | ❌ |
 /v2/skins | ❌ |
 /v2/specializations | ❌ |
 /v2/stories | ❌ |
 /v2/stories/seasons | ❌ |
 /v2/titles | ❌ |
 /v2/tokeninfo | ✔️🔑 | [`Gw2WebApiClient.V2.TokenInfo`](../api/Gw2Sharp.WebApi.V2.Clients.TokenInfoClient.html)
 /v2/traits | ❌ |
 ~~/v2/vendors~~ | ✖️ |
 /v2/worldbosses | ✔️📄📚📦 | [`Gw2WebApiClient.V2.WorldBosses`](../api/Gw2Sharp.WebApi.V2.Clients.WorldBossesClient.html)
 /v2/worlds | ❌ |
 /v2/wvw/abilities | ❌ |
 /v2/wvw/matches | ❌ |
 /v2/wvw/matches/overview | ❌ |
 /v2/wvw/matches/scores | ❌ |
 /v2/wvw/matches/stats | ❌ |
 /v2/wvw/matches/stats/`:id`/guilds/`:guild_id` | ❌ |
 /v2/wvw/matches/stats/`:id`/teams/`:team`/top/kdr | ❌ |
 /v2/wvw/matches/stats/`:id`/teams/`:team`/top/kills | ❌ |
 /v2/wvw/objectives | ❌ |
 /v2/wvw/ranks | ❌ |
 ~~/v2/wvw/rewardtracks~~ | ✖️ |
 /v2/wvw/upgrades | ❌ |
