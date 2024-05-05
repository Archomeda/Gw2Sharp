---
uid: Guides.Endpoints
title: Supported web API endpoints
---

# Supported web API endpoints
For your convenience, the following list gives an overview of the web API endpoints that are available in Gw2Sharp:

 Icon | Description
------|-------------
✔️   | Implemented; no additional endpoint features
❌   | Not implemented yet, but is available on API
✖️   | Missing on API
⚠️   | Deprecated; scheduled for removal in next major release
🔑   | Endpoint with authentication
🌐   | Endpoint with locale support
📆   | Endpoint with `Last-Modified` support
📄   | Endpoint with pagination support
📚   | Endpoint with bulk support
📦   | Endpoint with bulk all support

 Endpoint | Availability | Class
----------|----------------------|-------
 /v2/account | 🔑 | [`Gw2Client.WebApi.V2.Account`](../api/Gw2Sharp.WebApi.V2.Clients.AccountClient.html)
 /v2/account/achievements | 🔑 | [`Gw2Client.WebApi.V2.Account.Achievements`](../api/Gw2Sharp.WebApi.V2.Clients.AccountAchievementsClient.html)
 /v2/account/bank | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Bank`](../api/Gw2Sharp.WebApi.V2.Clients.AccountBankClient.html)
 /v2/account/buildstorage | 🔑📄📚📦 | [`Gw2Client.WebApi.V2.Account.BuildStorage`](../api/Gw2Sharp.WebApi.V2.Clients.AccountBuildStorageClient.html)
 /v2/account/dailycrafting | 🔑 | [`Gw2Client.WebApi.V2.Account.DailyCrafting`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDailyCraftingClient.html)
 /v2/account/dungeons | 🔑 | [`Gw2Client.WebApi.V2.Account.Dungeons`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDungeonsClient.html)
 /v2/account/dyes | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Dyes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountDyesClient.html)
 /v2/account/emotes | 🔑 | [`Gw2Client.WebApi.V2.Account.Emotes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountEmotesClient.html)
 /v2/account/finishers | 🔑 | [`Gw2Client.WebApi.V2.Account.Finishers`](../api/Gw2Sharp.WebApi.V2.Clients.AccountFinishersClient.html)
 /v2/account/gliders | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Gliders`](../api/Gw2Sharp.WebApi.V2.Clients.AccountGlidersClient.html)
 /v2/account/home | ✔️ | [`Gw2Client.WebApi.V2.Account.Home`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeClient.html)
 /v2/account/home/cats | 🔑 | [`Gw2Client.WebApi.V2.Account.Home.Cats`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeCatsClient.html)
 /v2/account/home/nodes | 🔑 | [`Gw2Client.WebApi.V2.Account.Home.Nodes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountHomeNodesClient.html)
 /v2/account/inventory | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Inventory`](../api/Gw2Sharp.WebApi.V2.Clients.AccountInventoryClient.html)
 /v2/account/legendaryarmory | 🔑 | [`Gw2Client.WebApi.V2.Account.LegendaryArmory`](../api/Gw2Sharp.WebApi.V2.Clients.AccountLegendaryArmoryClient.html)
 /v2/account/luck<br>➡️ /v2/account/progression | 🔑⚠️ | [`Gw2Client.WebApi.V2.Account.Luck`](../api/Gw2Sharp.WebApi.V2.Clients.AccountLuckClient.html)
 ~~/v2/account/mail~~ | ✖️ |
 /v2/account/mailcarriers | 🔑 | [`Gw2Client.WebApi.V2.Account.MailCarriers`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMailCarriersClient.html)
 /v2/account/mapchests | 🔑 | [`Gw2Client.WebApi.V2.Account.MapChests`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMapChestsClient.html)
 /v2/account/masteries | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Masteries`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMasteriesClient.html)
 /v2/account/mastery/points | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Mastery.Points`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMasteryPointsClient.html)
 /v2/account/materials | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Materials`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMaterialsClient.html)
 /v2/account/minis | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Minis`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMinisClient.html)
 /v2/account/mounts | ✔️ | [`Gw2Client.WebApi.V2.Account.Mounts`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsClient.html)
 /v2/account/mounts/skins | 🔑 | [`Gw2Client.WebApi.V2.Account.Mounts.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsSkinsClient.html)
 /v2/account/mounts/types | 🔑 | [`Gw2Client.WebApi.V2.Account.Mounts.Types`](../api/Gw2Sharp.WebApi.V2.Clients.AccountMountsTypesClient.html)
 /v2/account/novelties | 🔑 | [`Gw2Client.WebApi.V2.Account.Novelties.Types`](../api/Gw2Sharp.WebApi.V2.Clients.AccountNoveltiesClient.html)
 /v2/account/outfits | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Outfits`](../api/Gw2Sharp.WebApi.V2.Clients.AccountOutfitsClient.html)
 /v2/account/progression | 🔑 | [`Gw2Client.WebApi.V2.Account.Progression`](../api/Gw2Sharp.WebApi.V2.Clients.AccountProgressionClient.html)
 /v2/account/pvp/heroes | 🔑 | [`Gw2Client.WebApi.V2.Account.Pvp.Heroes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountPvpHeroesClient.html)
 /v2/account/raids | 🔑 | [`Gw2Client.WebApi.V2.Account.Raids`](../api/Gw2Sharp.WebApi.V2.Clients.AccountRaidsClient.html)
 /v2/account/recipes | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Recipes`](../api/Gw2Sharp.WebApi.V2.Clients.AccountRecipesClient.html)
 /v2/account/skins | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.AccountSkinsClient.html)
 /v2/account/titles | 🔑📆 | [`Gw2Client.WebApi.V2.Account.Titles`](../api/Gw2Sharp.WebApi.V2.Clients.AccountTitlesClient.html)
 /v2/account/wallet | 🔑 | [`Gw2Client.WebApi.V2.Account.Wallet`](../api/Gw2Sharp.WebApi.V2.Clients.AccountWalletClient.html)
 /v2/account/worldbosses | 🔑 | [`Gw2Client.WebApi.V2.Account.WorldBosses`](../api/Gw2Sharp.WebApi.V2.Clients.AccountWorldBossesClient.html)
 /v2/achievements | 🌐📄📚 | [`Gw2Client.WebApi.V2.Achievements`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsClient.html)
 /v2/achievements/categories | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Achievements.Categories`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsCategoriesClient.html)
 /v2/achievements/daily | ✔️ | [`Gw2Client.WebApi.V2.Achievements.Daily`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsDailyClient.html)
 /v2/achievements/daily/tomorrow | ✔️ | [`Gw2Client.WebApi.V2.Achievements.Daily.Tomorrow`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsDailyTomorrowClient.html)
 /v2/achievements/groups | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Achievements.Groups`](../api/Gw2Sharp.WebApi.V2.Clients.AchievementsGroupsClient.html)
 ~~/v2/adventures~~ | ✖️ |
 ~~/v2/adventures/`:id`/leaderboards~~ | ✖️ |
 ~~/v2/adventures/`:id`/leaderboards/:board/:region~~ | ✖️ |
 /v2/backstory/answers | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Backstory.Answers`](../api/Gw2Sharp.WebApi.V2.Clients.BackstoryAnswersClient.html)
 /v2/backstory/questions | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Backstory.Questions`](../api/Gw2Sharp.WebApi.V2.Clients.BackstoryQuestionsClient.html)
 /v2/build | ✔️ | [`Gw2Client.WebApi.V2.Build`](../api/Gw2Sharp.WebApi.V2.Clients.BuildClient.html)
 /v2/characters | 🔑📄📚📦 | [`Gw2Client.WebApi.V2.Characters`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersClient.html)
 /v2/characters/`:id` | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id]`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdClient.html)
 /v2/characters/`:id`/backstory | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Backstory`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdBackstoryClient.html)
 /v2/characters/`:id`/buildtabs | 🔑📄📚📦 | [`Gw2Client.WebApi.V2.Characters[id].BuildTabs`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdBuildTabsActiveClient.html)
 /v2/characters/`:id`/buildtabs/active | 🔑 | [`Gw2Client.WebApi.V2.Characters[id].BuildTabs.Active`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdBuildTabsActiveClient.html)
 /v2/characters/`:id`/core | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Core`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdCoreClient.html)
 /v2/characters/`:id`/crafting | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Crafting`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdCraftingClient.html)
 ~~/v2/characters/`:id`/dungeons~~ | ✖️ |
 /v2/characters/`:id`/equipment | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Equipment`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdEquipmentClient.html)
 /v2/characters/`:id`/equipmenttabs | 🔑📄📚📦 | [`Gw2Client.WebApi.V2.Characters[id].EquipmentTabs`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdEquipmentTabsClient.html)
 /v2/characters/`:id`/equipmenttabs/active | 🔑 | [`Gw2Client.WebApi.V2.Characters[id].EquipmentTabs.Active`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdEquipmentTabsActiveClient.html)
 /v2/characters/`:id`/heropoints | 🔑 | [`Gw2Client.WebApi.V2.Characters[id].HeroPoints`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdHeroPointsClient.html)
 /v2/characters/`:id`/inventory | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Inventory`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdInventoryClient.html)
 /v2/characters/`:id`/quests | 🔑 | [`Gw2Client.WebApi.V2.Characters[id].Quests`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdQuestsClient.html)
 /v2/characters/`:id`/recipes | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Recipes`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdRecipesClient.html)
 /v2/characters/`:id`/sab | 🔑 | [`Gw2Client.WebApi.V2.Characters[id].Sab`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdSabClient.html)
 /v2/characters/`:id`/training | 🔑📆 | [`Gw2Client.WebApi.V2.Characters[id].Training`](../api/Gw2Sharp.WebApi.V2.Clients.CharactersIdTrainingClient.html)
 /v2/colors | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Colors`](../api/Gw2Sharp.WebApi.V2.Clients.ColorsClient.html)
 /v2/commerce/delivery | 🔑 | [`Gw2Client.WebApi.V2.Commerce.Delivery`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceDeliveryClient.html)
 /v2/commerce/exchange | ✔️ | [`Gw2Client.WebApi.V2.Commerce.Exchange`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeClient.html)
 /v2/commerce/exchange/coins | ✔️ | [`Gw2Client.WebApi.V2.Commerce.Exchange.Coins`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeCoinsClient.html)
 /v2/commerce/exchange/gems | ✔️ | [`Gw2Client.WebApi.V2.Commerce.Exchange.Gems`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceExchangeGemsClient.html)
 /v2/commerce/listings | 📄📚 | [`Gw2Client.WebApi.V2.Commerce.Listings`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceListingsClient.html)
 /v2/commerce/prices | 📄📚 | [`Gw2Client.WebApi.V2.Commerce.Prices`](../api/Gw2Sharp.WebApi.V2.Clients.CommercePricesClient.html)
 /v2/commerce/transactions  | 🔑 | [`Gw2Client.WebApi.V2.Commerce.Transactions`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsClient.html)
 /v2/commerce/transactions/current  | 🔑 | [`Gw2Client.WebApi.V2.Commerce.Transactions.Current`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentClient.html)
 /v2/commerce/transactions/current/buys  | 🔑📄 | [`Gw2Client.WebApi.V2.Commerce.Transactions.Current.Buys`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentBuysClient.html)
 /v2/commerce/transactions/current/sells  | 🔑📄 | [`Gw2Client.WebApi.V2.Commerce.Transactions.Current.Sells`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsCurrentSellsClient.html)
 /v2/commerce/transactions/history  | 🔑 | [`Gw2Client.WebApi.V2.Commerce.Transactions.History`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistoryClient.html)
 /v2/commerce/transactions/history/buys  | 🔑📄 | [`Gw2Client.WebApi.V2.Commerce.Transactions.History.Buys`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistoryBuysClient.html)
 /v2/commerce/transactions/history/sells  | 🔑📄 | [`Gw2Client.WebApi.V2.Commerce.Transactions.History.Sells`](../api/Gw2Sharp.WebApi.V2.Clients.CommerceTransactionsHistorySellsClient.html)
 /v2/continents  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsClient.html)
 /v2/continents/`:continent`/<br>floors  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>pois  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Pois`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsPoisClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>sectors  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Sectors`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsSectorsClient.html)
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>tasks  | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Tasks`](../api/Gw2Sharp.WebApi.V2.Clients.ContinentsFloorsRegionsMapsTasksClient.html)
 /v2/createsubtoken | 🔑 | [`Gw2Client.WebApi.V2.CreateSubtoken`](../api/Gw2Sharp.WebApi.V2.Clients.CreateSubtokenClient.html)
 /v2/currencies | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Currencies`](../api/Gw2Sharp.WebApi.V2.Clients.CurrenciesClient.html)
 /v2/dailycrafting | 📄📚📦 | [`Gw2Client.WebApi.V2.DailyCrafting`](../api/Gw2Sharp.WebApi.V2.Clients.DailyCraftingClient.html)
 /v2/dungeons | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Dungeons`](../api/Gw2Sharp.WebApi.V2.Clients.DungeonsClient.html)
 /v2/emblem | ✔️ | [`Gw2Client.WebApi.V2.Emblem`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemClient.html)
 /v2/emblem/backgrounds | 📄📚📦 | [`Gw2Client.WebApi.V2.Emblem.Backgrounds`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemBackgroundsClient.html)
 /v2/emblem/foregrounds | 📄📚📦 | [`Gw2Client.WebApi.V2.Emblem.Foregrounds`](../api/Gw2Sharp.WebApi.V2.Clients.EmblemForegroundsClient.html)
 ~~/v2/events~~ | ✖️ |
 ~~/v2/events-state~~ | ✖️ |
 /v2/files | 📄📚📦 | [`Gw2Client.WebApi.V2.Files`](../api/Gw2Sharp.WebApi.V2.Clients.FilesClient.html)
 /v2/finishers | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Finishers`](../api/Gw2Sharp.WebApi.V2.Clients.FinishersClient.html)
 ~~/v2/gemstore/catalog~~ | ✖️ |
 /v2/gliders | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Gliders`](../api/Gw2Sharp.WebApi.V2.Clients.GlidersClient.html)
 /v2/guild/`:id` | 🔑 | [`Gw2Client.WebApi.V2.Guild[id]`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdClient.html)
 /v2/guild/`:id`/log | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Log`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdClient.html)
 /v2/guild/`:id`/members | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Members`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdMembersClient.html)
 /v2/guild/`:id`/ranks | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Ranks`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdRanksClient.html)
 /v2/guild/`:id`/stash | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Stash`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdStashClient.html)
 /v2/guild/`:id`/storage | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Storage`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdStorageClient.html)
 /v2/guild/`:id`/teams | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Teams`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdTeamsClient.html)
 /v2/guild/`:id`/treasury | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Treasury`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdTreasuryClient.html)
 /v2/guild/`:id`/upgrades | 🔑 | [`Gw2Client.WebApi.V2.Guild[id].Upgrades`](../api/Gw2Sharp.WebApi.V2.Clients.GuildIdUpgradesClient.html)
 /v2/guild/permissions | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Guild.Permissions`](../api/Gw2Sharp.WebApi.V2.Clients.GuildPermissionsClient.html)
 /v2/guild/search | ✔️ | [`Gw2Client.WebApi.V2.Guild.Search`](../api/Gw2Sharp.WebApi.V2.Clients.GuildSearchClient.html)
 /v2/guild/upgrades | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Guild.Upgrades`](../api/Gw2Sharp.WebApi.V2.Clients.GuildUpgradesClient.html)
 /v2/home | ✔️ | [`Gw2Client.WebApi.V2.Home`](../api/Gw2Sharp.WebApi.V2.Clients.HomeClient.html)
 /v2/home/cats | 📄📚📦 | [`Gw2Client.WebApi.V2.Home.Cats`](../api/Gw2Sharp.WebApi.V2.Clients.HomeCatsClient.html)
 /v2/home/nodes | 📄📚📦 | [`Gw2Client.WebApi.V2.Home.Nodes`](../api/Gw2Sharp.WebApi.V2.Clients.HomeNodesClient.html)
 /v2/items | 🌐📄📚 | [`Gw2Client.WebApi.V2.Items`](../api/Gw2Sharp.WebApi.V2.Clients.ItemsClient.html)
 /v2/itemstats | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Itemstats`](../api/Gw2Sharp.WebApi.V2.Clients.ItemstatsClient.html)
 /v2/legendaryarmory | 📄📚📦 | [`Gw2Client.WebApi.V2.LegendaryArmory`](../api/Gw2Sharp.WebApi.V2.Clients.LegendaryArmoryClient.html)
 /v2/legends | 📄📚📦 | [`Gw2Client.WebApi.V2.Legends`](../api/Gw2Sharp.WebApi.V2.Clients.LegendsClient.html)
 /v2/mailcarriers | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.MailCarriers`](../api/Gw2Sharp.WebApi.V2.Clients.MailCarriersClient.html)
 /v2/mapchests | 📄📚📦 | [`Gw2Client.WebApi.V2.MapChests`](../api/Gw2Sharp.WebApi.V2.Clients.MapChestsClient.html)
 /v2/maps | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Maps`](../api/Gw2Sharp.WebApi.V2.Clients.MapsClient.html)
 /v2/masteries | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Masteries`](../api/Gw2Sharp.WebApi.V2.Clients.MasteriesClient.html)
 /v2/materials | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Materials`](../api/Gw2Sharp.WebApi.V2.Clients.MaterialsClient.html)
 /v2/minis | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Minis`](../api/Gw2Sharp.WebApi.V2.Clients.MinisClient.html)
 /v2/mounts | ✔️ | [`Gw2Client.WebApi.V2.Mounts`](../api/Gw2Sharp.WebApi.V2.Clients.MountsClient.html)
 /v2/mounts/skins | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Mounts.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.MountsSkinsClient.html)
 /v2/mounts/types | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Mounts.Types`](../api/Gw2Sharp.WebApi.V2.Clients.MountsTypesClient.html)
 /v2/novelties | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Novelties`](../api/Gw2Sharp.WebApi.V2.Clients.NoveltiesClient.html)
 /v2/outfits | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Outfits`](../api/Gw2Sharp.WebApi.V2.Clients.OutfitsClient.html)
 /v2/pets | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Pets`](../api/Gw2Sharp.WebApi.V2.Clients.PetsClient.html)
 /v2/professions | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Professions`](../api/Gw2Sharp.WebApi.V2.Clients.ProfessionsClient.html)
 /v2/pvp | ✔️ | [`Gw2Client.WebApi.V2.Pvp`](../api/Gw2Sharp.WebApi.V2.Clients.PvpClient.html)
 /v2/pvp/amulets | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Pvp.Amulets`](../api/Gw2Sharp.WebApi.V2.Clients.PvpAmuletsClient.html)
 /v2/pvp/games | 🔑📄📚📦 | [`Gw2Client.WebApi.V2.Pvp.Games`](../api/Gw2Sharp.WebApi.V2.Clients.PvpGamesClient.html)
 /v2/pvp/heroes | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Pvp.Heroes`](../api/Gw2Sharp.WebApi.V2.Clients.PvpHeroesClient.html)
 /v2/pvp/ranks | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Pvp.Ranks`](../api/Gw2Sharp.WebApi.V2.Clients.PvpRanksClient.html)
 ~~/v2/pvp/rewardtracks~~ | ✖️ |
 ~~/v2/pvp/runes~~ | ✖️ |
 /v2/pvp/seasons | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Pvp.Seasons`](../api/Gw2Sharp.WebApi.V2.Clients.PvpSeasonsClient.html)
 /v2/pvp/seasons/`:id`/leaderboards | ✔️ | [`Gw2Client.WebApi.V2.Pvp.Seasons[id].Leaderboards`](../api/Gw2Sharp.WebApi.V2.Clients.PvpSeasonsLeaderboardsClient.html)
 /v2/pvp/seasons/`:id`/leaderboards/`:board`/`:region` | 📄 | [`Gw2Client.WebApi.V2.Pvp.Seasons[id].Leaderboards[board][region]`](../api/Gw2Sharp.WebApi.V2.Clients.PvpSeasonsLeaderboardsRegionIdClient.html)
 ~~/v2/pvp/sigils~~ | ✖️ |
 /v2/pvp/standings | 🔑 | [`Gw2Client.WebApi.V2.Pvp.Standings`](../api/Gw2Sharp.WebApi.V2.Clients.PvpStandingsClient.html)
 /v2/pvp/stats | 🔑 | [`Gw2Client.WebApi.V2.Pvp.Stats`](../api/Gw2Sharp.WebApi.V2.Clients.PvpStatsClient.html)
 /v2/quaggans | 📄📚📦 | [`Gw2Client.WebApi.V2.Quaggans`](../api/Gw2Sharp.WebApi.V2.Clients.QuaggansClient.html)
 /v2/quests | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Quests`](../api/Gw2Sharp.WebApi.V2.Clients.QuestsClient.html)
 /v2/races | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Races`](../api/Gw2Sharp.WebApi.V2.Clients.RacesClient.html)
 /v2/raids | 📄📚📦 | [`Gw2Client.WebApi.V2.Raids`](../api/Gw2Sharp.WebApi.V2.Clients.RaidsClient.html)
 /v2/recipes | 📄📚 | [`Gw2Client.WebApi.V2.Recipes`](../api/Gw2Sharp.WebApi.V2.Clients.RecipesClient.html)
 /v2/recipes/search | ✔️ | [`Gw2Client.WebApi.V2.Recipes.Search`](../api/Gw2Sharp.WebApi.V2.Clients.RecipesSearchClient.html)
 /v2/skills | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Skills`](../api/Gw2Sharp.WebApi.V2.Clients.SkillsClient.html)
 /v2/skins | 🌐📄📚 | [`Gw2Client.WebApi.V2.Skins`](../api/Gw2Sharp.WebApi.V2.Clients.SkinsClient.html)
 /v2/specializations | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Specializations`](../api/Gw2Sharp.WebApi.V2.Clients.SpecializationsClient.html)
 /v2/stories | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Stories`](../api/Gw2Sharp.WebApi.V2.Clients.StoriesClient.html)
 /v2/stories/seasons | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Stories.Seasons`](../api/Gw2Sharp.WebApi.V2.Clients.StoriesSeasonsClient.html)
 /v2/titles | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Titles`](../api/Gw2Sharp.WebApi.V2.Clients.TitlesClient.html)
 /v2/tokeninfo | 🔑 | [`Gw2Client.WebApi.V2.TokenInfo`](../api/Gw2Sharp.WebApi.V2.Clients.TokenInfoClient.html)
 /v2/traits | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Traits`](../api/Gw2Sharp.WebApi.V2.Clients.TraitsClient.html)
 ~~/v2/vendors~~ | ✖️ |
 /v2/worldbosses | 📄📚📦 | [`Gw2Client.WebApi.V2.WorldBosses`](../api/Gw2Sharp.WebApi.V2.Clients.WorldBossesClient.html)
 /v2/worlds | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Worlds`](../api/Gw2Sharp.WebApi.V2.Clients.WorldsClient.html)
 /v2/wvw/abilities | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Abilities`](../api/Gw2Sharp.WebApi.V2.Clients.WvwAbilitiesClient.html)
 /v2/wvw/matches | 📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Matches`](../api/Gw2Sharp.WebApi.V2.Clients.WvwMatchesClient.html)
 /v2/wvw/matches/overview | 📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Matches.Overview`](../api/Gw2Sharp.WebApi.V2.Clients.WvwMatchesOverviewClient.html)
 /v2/wvw/matches/scores | 📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Matches.Scores`](../api/Gw2Sharp.WebApi.V2.Clients.WvwMatchesScoresClient.html)
 /v2/wvw/matches/stats | 📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Matches.Stats`](../api/Gw2Sharp.WebApi.V2.Clients.WvwMatchesStatsClient.html)
 ~~/v2/wvw/matches/stats/`:id`/guilds/`:guild_id`~~ | ✖️ | *Broken on the API as of 2020-12-22*
 ~~/v2/wvw/matches/stats/`:id`/teams/`:team`/top/kdr~~ | ✖️ | *Broken on the API as of 2020-12-22*
 ~~/v2/wvw/matches/stats/`:id`/teams/`:team`/top/kills~~ | ✖️ | *Broken on the API as of 2020-12-22*
 /v2/wvw/objectives | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Objectives`](../api/Gw2Sharp.WebApi.V2.Clients.WvwObjectivesClient.html)
 /v2/wvw/ranks | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Ranks`](../api/Gw2Sharp.WebApi.V2.Clients.WvwRanksClient.html)
 ~~/v2/wvw/rewardtracks~~ | ✖️ |
 /v2/wvw/upgrades | 🌐📄📚📦 | [`Gw2Client.WebApi.V2.Wvw.Upgrades`](../api/Gw2Sharp.WebApi.V2.Clients.WvwUpgradesClient.html)
