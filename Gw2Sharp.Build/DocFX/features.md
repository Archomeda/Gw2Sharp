# Endpoint Feature List
Gw2Sharp is not finished yet, and development is being done whenever I have spare time.
For your convenience, the following list gives an overview of the endpoints that are already available in this library:

 Icon | Description
------|-------------
✔️   | Implemented
❌   | Not implemented yet, but is available on API
❌✨ | Not implemented yet, because it uses the new API versioning system
✖️   | Missing on API
➡️   | Endpoint has moved, will deprecate in the future
🔑   | Endpoint with authentication
🌐   | Endpoint with locale support
📆   | Endpoint with `Last-Modified` support (has yet to be implemented)
📄   | Endpoint with pagination support
📚   | Endpoint with bulk support
📦   | Endpoint with bulk all support

 Endpoint | Availability | Class
----------|----------------------|-------
 /v2/account | ✔️🔑 | `Gw2WebApiClient.V2.Account`
 /v2/account/achievements | ✔️🔑 | `Gw2WebApiClient.V2.Account.Achievements`
 /v2/account/bank | ✔️🔑 | `Gw2WebApiClient.V2.Account.Bank`
 /v2/account/dungeons | ✔️🔑 | `Gw2WebApiClient.V2.Account.Dungeons`
 /v2/account/dyes | ✔️🔑 | `Gw2WebApiClient.V2.Account.Dyes`
 /v2/account/finishers | ✔️🔑 | `Gw2WebApiClient.V2.Account.Finishers`
 /v2/account/gliders | ✔️🔑 | `Gw2WebApiClient.V2.Account.Gliders`
 /v2/account/home | ✔️🔑 | `Gw2WebApiClient.V2.Account.Home`
 /v2/account/home/cats | ✔️🔑 | `Gw2WebApiClient.V2.Account.Home.Cats`
 /v2/account/home/nodes | ✔️🔑 | `Gw2WebApiClient.V2.Account.Home.Nodes`
 /v2/account/inventory | ✔️🔑 | `Gw2WebApiClient.V2.Account.Inventory`
 /v2/account/luck | ❌✨ | 
 ~~/v2/account/mail~~ | ✖️ | 
 /v2/account/mailcarriers | ✔️🔑 | `Gw2WebApiClient.V2.Account.MailCarriers`
 /v2/account/mapchests | ❌✨ | 
 /v2/account/masteries | ✔️🔑 | `Gw2WebApiClient.V2.Account.Masteries`
 /v2/account/mastery/points | ✔️🔑 | `Gw2WebApiClient.V2.Account.Mastery.Points`
 /v2/account/materials | ✔️🔑 | `Gw2WebApiClient.V2.Account.Materials`
 /v2/account/minis | ✔️🔑 | `Gw2WebApiClient.V2.Account.Minis`
 /v2/account/mounts | ❌✨ | 
 /v2/account/mounts/skins | ❌✨ | 
 /v2/account/mounts/types | ❌✨ | 
 /v2/account/outfits | ✔️🔑 | `Gw2WebApiClient.V2.Account.Outfits`
 /v2/account/pvp/heroes | ✔️🔑 | `Gw2WebApiClient.V2.Account.Pvp.Heroes`
 /v2/account/raids | ✔️🔑 | `Gw2WebApiClient.V2.Account.Raids`
 /v2/account/recipes | ✔️🔑 | `Gw2WebApiClient.V2.Account.Recipes`
 /v2/account/skins | ✔️🔑 | `Gw2WebApiClient.V2.Account.Skins`
 /v2/account/titles | ✔️🔑 | `Gw2WebApiClient.V2.Account.Titles`
 /v2/account/wallet | ✔️🔑 | `Gw2WebApiClient.V2.Account.Wallet`
 /v2/account/worldbosses | ❌✨ | 
 /v2/achievements | ✔️🌐📄📚 | `Gw2WebApiClient.V2.Achievements`
 /v2/achievements/categories | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Achievements.Categories`
 /v2/achievements/daily | ✔️ | `Gw2WebApiClient.V2.Achievements.Daily`
 /v2/achievements/daily/tomorrow | ✔️ | `Gw2WebApiClient.V2.Achievements.Daily.Tomorrow`
 /v2/achievements/groups | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Achievements.Groups`
 ~~/v2/adventures~~ | ✖️ | 
 ~~/v2/adventures/`:id`/leaderboards~~ | ✖️ | 
 ~~/v2/adventures/`:id`/leaderboards/:board/:region~~ | ✖️ | 
 /v2/backstory/answers | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Backstory.Answers`
 /v2/backstory/questions | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Backstory.Questions`
 /v2/build | ✔️ | `Gw2WebApiClient.V2.Build`
 /v2/cats | ✔️📄📚📦➡️ | `Gw2WebApiClient.V2.Cats`
 /v2/characters | ✔️🔑📄📚📦 | `Gw2WebApiClient.V2.Characters`
 /v2/characters/`:id`/backstory | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Backstory`
 /v2/characters/`:id`/core | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Core`
 /v2/characters/`:id`/crafting | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Crafting`
 ~~/v2/characters/`:id`/dungeons~~ | ✖️ | 
 /v2/characters/`:id`/equipment | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Equipment`
 /v2/characters/`:id`/heropoints | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].HeroPoints`
 /v2/characters/`:id`/inventory | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Inventory`
 /v2/characters/`:id`/recipes | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Recipes`
 /v2/characters/`:id`/sab | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Sab`
 /v2/characters/`:id`/skills | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Skills`
 /v2/characters/`:id`/specializations | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Specializations`
 /v2/characters/`:id`/training | ✔️🔑 | `Gw2WebApiClient.V2.Characters[id].Training`
 /v2/colors | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Colors`
 /v2/commerce/delivery | ✔️🔑 | `Gw2WebApiClient.V2.Commerce.Delivery`
 /v2/commerce/exchange | ✔️ | `Gw2WebApiClient.V2.Commerce.Exchange`
 /v2/commerce/exchange/coins | ✔️ | `Gw2WebApiClient.V2.Commerce.Exchange.Coins`
 /v2/commerce/exchange/gems | ✔️ | `Gw2WebApiClient.V2.Commerce.Exchange.Gems`
 /v2/commerce/listings | ✔️📄📚 | `Gw2WebApiClient.V2.Commerce.Listings`
 /v2/commerce/prices | ✔️📄📚 | `Gw2WebApiClient.V2.Commerce.Prices`
 /v2/commerce/transactions  | ✔️🔑 | `Gw2WebApiClient.V2.Commerce.Transactions`
 /v2/commerce/transactions/current  | ✔️🔑 | `Gw2WebApiClient.V2.Commerce.Transactions.Current`
 /v2/commerce/transactions/current/buys  | ✔️🔑📄 | `Gw2WebApiClient.V2.Commerce.Transactions.Current.Buys`
 /v2/commerce/transactions/current/sells  | ✔️🔑📄 | `Gw2WebApiClient.V2.Commerce.Transactions.Current.Sells`
 /v2/commerce/transactions/history  | ✔️🔑 | `Gw2WebApiClient.V2.Commerce.Transactions.History`
 /v2/commerce/transactions/history/buys  | ✔️🔑📄 | `Gw2WebApiClient.V2.Commerce.Transactions.History.Buys`
 /v2/commerce/transactions/history/sells  | ✔️🔑📄 | `Gw2WebApiClient.V2.Commerce.Transactions.History.Sells`
 /v2/continents  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents`
 /v2/continents/`:continent`/<br>floors  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors`
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions`
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps`
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>pois  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Pois`
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>sectors  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Sectors`
 /v2/continents/`:continent`/<br>floors/`:floor`/<br>regions/`:region`/<br>maps/`:map`/<br>tasks  | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Continents[continent]`<br>`.Floors[floor]`<br>`.Regions[region]`<br>`.Maps[map]`<br>`.Tasks`
 /v2/currencies | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Currencies`
 /v2/dailycrafting | ❌✨ | 
 /v2/dungeons | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Dungeons`
 /v2/emblem | ✔️ | `Gw2WebApiClient.V2.Emblem`
 /v2/emblem/backgrounds | ✔️📄📚📦 | `Gw2WebApiClient.V2.Emblem.Backgrounds`
 /v2/emblem/foregrounds | ✔️📄📚📦 | `Gw2WebApiClient.V2.Emblem.Foregrounds`
 ~~/v2/events~~ | ✖️ | 
 ~~/v2/events-state~~ | ✖️ | 
 /v2/files | ✔️📄📚📦 | `Gw2WebApiClient.V2.Files`
 /v2/finishers | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Finishers`
 ~~/v2/gemstore/catalog~~ | ✖️ | 
 /v2/gliders | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Gliders`
 /v2/guild/`:id` | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id]`
 /v2/guild/`:id`/log | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Log`
 /v2/guild/`:id`/members | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Members`
 /v2/guild/`:id`/ranks | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Ranks`
 /v2/guild/`:id`/stash | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Stash`
 /v2/guild/`:id`/storage | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Storage`
 /v2/guild/`:id`/teams | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Teams`
 /v2/guild/`:id`/treasury | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Treasury`
 /v2/guild/`:id`/upgrades | ✔️🔑 | `Gw2WebApiClient.V2.Guild[id].Upgrades`
 /v2/guild/permissions | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Guild.Permissions`
 /v2/guild/search | ✔️ | `Gw2WebApiClient.V2.Guild.Search`
 /v2/guild/upgrades | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Guild.Upgrades`
 /v2/home | ❌ | 
 /v2/home/cats | ✔️📄📚📦 | `Gw2WebApiClient.V2.Cats` ➡️
 /v2/home/nodes | ❌ | 
 /v2/items | ✔️🌐📄📚 | `Gw2WebApiClient.V2.Items`
 /v2/itemstats | ✔️🌐📄📚📦 | `Gw2WebApiClient.V2.Itemstats`
 /v2/legends | ✔️📄📚📦 | `Gw2WebApiClient.V2.Legends`
 /v2/mailcarriers | ❌ | 
 /v2/mapchests | ❌✨ | 
 /v2/maps | ❌ | 
 /v2/masteries | ❌ | 
 /v2/materials | ❌ | 
 /v2/minis | ❌ | 
 /v2/mounts | ❌✨ | 
 /v2/mounts/skins | ❌✨ | 
 /v2/mounts/types | ❌✨ | 
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
 /v2/races | ❌✨ | 
 /v2/raids | ❌ | 
 /v2/recipes | ❌ | 
 /v2/recipes/search | ❌ | 
 /v2/skills | ❌ | 
 /v2/skins | ❌ | 
 /v2/specializations | ❌ | 
 /v2/stories | ❌ | 
 /v2/stories/seasons | ❌ | 
 /v2/titles | ❌ | 
 /v2/tokeninfo | ❌ | 
 /v2/traits | ❌ | 
 ~~/v2/vendors~~ | ✖️ | 
 /v2/worldbosses | ❌✨ | 
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
