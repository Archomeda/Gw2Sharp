# Gw2Sharp History

## 0.8.0
This release applies the schema changes of 2019-12-19, which includes the build and equipment template update from October 2019.

### Endpoints
- Add `/v2/account/buildstorage`
- Add `/v2/account/buildstorage/active`
- Add `/v2/characters/:id/buildtabs`
- Add `/v2/characters/:id/buildtabs/active`
- Add `/v2/characters/:id/equipmenttabs`
- Add `/v2/characters/:id/equipmenttabs/active`
- Add `BuildStorageSlots` property to `/v2/account`
- Add `BuildTabsUnlocked`, `ActiveBuildTab` and `BuildTabs` properties to `/v2/characters/:id`
- Add `EquipmentTabsUnlocked`, `ActiveEquipmentTab` and `EquipmentTabs` properties to `/v2/characters/:id`
- Add `Equipment[i].Location` and `Equipment[i].Tabs` properties to `/v2/characters/:id`
- Add `Code` property to `/v2/legends`
- Add `Code` and `SkillsByPalette` properties to `/v2/professions`
- Marked `/v2/characters/:id/skills` as deprecated
- Marked `/v2/characters/:id/specializations` as deprecated
- Marked `Skills` and `Specializations` properties as deprecated

### Services
- Update MumbleLink to support new features ([#33](https://github.com/Archomeda/Gw2Sharp/pull/33)):
  - UI states: DoesGameHaveFocus, IsCompetitiveMode, DoesAnyInputHaveFocus (not yet implemented in GW2)

### Fixes
- `GuidConverter` now checks for `null` when deserializing JSON objects ([#28](https://github.com/Archomeda/Gw2Sharp/issues/28))
  - **Breaking:** Also changes the property `Guild` in `Gw2Sharp.WebApi.V2.Models.Character` to be nullable

### Refactoring
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.IAuthenticatedClient` no longer accepts the object type as generic type parameter; it's now just an interface without any type parameters
- **Breaking:** `Gw2Sharp.WebApi.Caching.ICacheMethod.FlushAsync` has been renamed to `ClearAsync` to better indicate its purpose ([#34](https://github.com/Archomeda/Gw2Sharp/pull/34)) (all deprecations will be fully removed in 0.9.0+):
  - `FlushAsync` is marked as deprecated and is unused in Gw2Sharp from now on

### Deprecation notes
The deprecated endpoints and properties can still be used for now.
The API still provides the endpoints, and the properties have been implemented with backwards compatibility code on Gw2Sharp's end.
However, it's advised to update as soon as possible, as these deprecations will be fully removed starting with the next major prerelease version 0.9.0.

---

## 0.7.4
### Services
- Chat link parsing and rendering is now supported ([#23](https://github.com/Archomeda/Gw2Sharp/issues/23), [#24](https://github.com/Archomeda/Gw2Sharp/pull/24))

## 0.7.3
Gw2Sharp has moved to the release version of .NET Core 3.0.
This only means that .NET Core 3.0 is used for compiling, while .NET Standard 2.0 is still targeted.
From now on, at least Visual Studio 2019 16.3 is required when working with the source code.
This shouldn't impact any NuGet package users.

### Dependencies
- System.IO.Compression has been removed as explicit dependency as it's already referenced from the framework

### Endpoints
- Add `/v2/account/emotes`
- Add `/v2/emotes`
- Add `/v2/skills`

### Services
- Update MumbleLink to support new features ([#18](https://github.com/Archomeda/Gw2Sharp/pull/18)):
  - Current character selected specialization
  - UI states: IsMapOpen, IsCompassTopRight, IsCompassRotationEnabled
  - Compass size
  - Compass rotation
  - Player location map
  - Map center
  - Map scale

### Fixes
- `IHttpResponseStream` now implements `IDisposable` because it's assumed that it owns the stream that's passed in the constructor
- GUID ids are converted to uppercase before being used in API request URLs ([#22](https://github.com/Archomeda/Gw2Sharp/issues/22))

## 0.7.1
### Services
- Add Mumble Link client as `Gw2MumbleClient`, which can be accessed through `Gw2Client.Mumble` ([#7](https://github.com/Archomeda/Gw2Sharp/issues/7), [#16](https://github.com/Archomeda/Gw2Sharp/pull/16))

### Lifetime
- Because of the introduction of the `Gw2MumbleClient` that implements `IDisposable` (because it holds a reference to a memory mapped file that needs to be disposed), `Gw2Client` now implements `IDisposable` as well and should be disposed accordingly  
  **Note:** This is a breaking change if you decide to start using the Mumble Link client, because it will only create disposable resources on the first call to `.Update()` in the `Gw2MumbleClient`

### Fixes
- Fix `RecipesClient` to correctly inherit from `BaseEndpointBulkClient` instead of `BaseEndpointBulkAllClient` (`/v2/recipes` doesn't support expanding all items at once, and this was incorrectly set on the implementation, the interface was correct) ([#14](https://github.com/Archomeda/Gw2Sharp/pull/14) by [@darthmaim](https://github.com/darthmaim))

## 0.7.0
### Endpoints
- **Breaking:** `Gw2Sharp.WebApi.V2.Models.CharacterCraftingDiscipline` has had the type of its property `Discipline` changed from `string` to `ApiEnum<CraftingDisciplineType>`
- **Breaking:** `Gw2Sharp.WebApi.V2.Models.MasteryLevel` has had the type of its property `Icon` fixed from `string` to `RenderUrl`
- **Breaking:** Enum value `TwoHandedToy` in `Gw2Sharp.WebApi.V2.Models.ItemWeaponType` has had its name fixed to `ToyTwoHanded`
- Add `/v2/recipes`
- Add `/v2/recipes/search`
- Add missing enum `AgonyResistance` in `Gw2Sharp.WebApi.V2.Models.ItemAttributeType`
- Add missing enums `Currency`, `RandomUnlock` and `MountRandomUnlock` in `Gw2Sharp.WebApi.V2.Models.ItemConsumableType`
- Add missing enum `Immediate` in `Gw2Sharp.WebApi.V2.Models.ItemContainerType`
- Add missing enum `Female` in `Gw2Sharp.WebApi.V2.Models.ItemRestriction`
- Add missing enum `Key` in `Gw2Sharp.WebApi.V2.Models.ItemType`
- Add missing enums `SharedSlot`, `Minipet` and `MountSkin` in `Gw2Sharp.WebApi.V2.Models.ItemUnlockType`
- Add missing item type `Key` as `Gw2Sharp.WebApi.V2.Models.ItemKey` for pattern matching

### Fixes
- Classes that implement `Gw2Sharp.WebApi.V2.Models.ICastableType` to support polymorphism (e.g. various items from `/v2/items`) should no longer fail to deserialize with `RenderUrl` properties ([#12](https://github.com/Archomeda/Gw2Sharp/issues/12))

### Refactoring
- The endpoint clients `Gw2Sharp.WebApi.V2.Clients.CommerceExchangeCoinsClient` and `Gw2Sharp.WebApi.V2.Clients.CommerceExchangeGemsClient` no longer inherit from `Gw2Sharp.WebApi.V2.Clients.BaseEndpointBlobClient` and instead inherit from `Gw2Sharp.WebApi.BlobClient` (they require the quantity to be given and cannot return a valid blob response without it)

---

## 0.6.1
### Endpoints
- Change property `Emblem` in `Gw2Sharp.WebApi.V2.Models.Guild` to be nullable because the API might leave this property out ([#10](https://github.com/Archomeda/Gw2Sharp/issues/10))

### Fixes
- Fix default instantiations of `ApiEnum` and `ApiFlags` that might cause `InvalidCastException`s when requesting data by removing the non-generic `ApiEnum` and `ApiFlags` variants (they were only used internally for easy casting when deserializing) ([#10](https://github.com/Archomeda/Gw2Sharp/issues/10))

## 0.6.0
### Endpoints
- **Breaking:** `Gw2Sharp.WebApi.V2.Models.GuildTeam` has had the type of its property `Ladders` changed from `PvpStatsLadders` to `IReadOnlyDictionary<string, PvpStatsAggregate>`
  (reason: the keys in this property of this endpoint (`/v2/guild/:id/teams`) are actually dynamic, just like the ones in `/v2/pvp/stats`)
- Hitting the rate limit will now throw a `TooManyRequestsException` instead of `UnexpectedStatusException` ([#8](https://github.com/Archomeda/Gw2Sharp/issues/8))
- Fix guild id from not being used in guild endpoints ([#9](https://github.com/Archomeda/Gw2Sharp/issues/9))
- Add `/v2/pvp/amulets`
- Add `/v2/pvp/games`
- Add `/v2/pvp/heroes`
- Add `/v2/pvp/ranks`
- Add `/v2/pvp/seasons`
- Add `/v2/pvp/seasons/:id/leaderboards`
- Add `/v2/pvp/seasons/:id/leaderboards/:board/:region`
- Add `/v2/pvp/standings`
- Add `/v2/pvp/stats`
- Add `/v2/quaggans`
- Add `/v2/quests`
- Add `/v2/races`
- Add `/v2/raids`
- Change `ICharactersIdClient` to use `IBlobClient<Character>` in order to consistently accept `GetAsync()` (`/v2/characters/:id`)
- Change `IContinentsIdClient` to use `IBlobClient<Continent>` in order to consistently accept `GetAsync()` (`/v2/continents/:continent_id`)
- Change `IContinentsFloorsIdClient` to use `IBlobClient<ContinentFloor>` in order to consistently accept `GetAsync()` (`/v2/continents/:continent_id/floors/:floor_id`)
- Change `IContinentsFloorsRegionsIdClient` to use `IBlobClient<ContinentFloorRegion>` in order to consistently accept `GetAsync()` (`/v2/continents/:id/floors/:floor_id/regions/:region_id`)
- Change `IContinentsFloorsRegionsMapsIdClient` to use `IBlobClient<ContinentFloorRegionMap>` in order to consistently accept `GetAsync()` (`/v2/continents/:id/floors/:floor_id/regions/:region_id/maps/:map_id`)

### Caching
- Fix locale setting from being ignored when generating the cache id for cachable endpoints

### Refactoring
- **Breaking:** The class `Gw2Sharp.WebApi.V2.Models.PvpStatsLadders` has been fully removed since it's no longer used
- **Breaking:** The following properties have had their types changed from `DateTime` to `DateTimeOffset`:
  - `LastModified` and `Created` in `Gw2Sharp.WebApi.V2.Models.Account`
  - `LastModified` and `Created` in `Gw2Sharp.WebApi.V2.Models.Character`
  - `LastModified` and `Created` in `Gw2Sharp.WebApi.V2.Models.CharactersCore`
  - `Created` in `Gw2Sharp.WebApi.V2.Models.CommerceTransactionCurrent`
  - `Created` and `Purchased` in `Gw2Sharp.WebApi.V2.Models.CommerceTransactionHistory`
  - `Time` in `Gw2Sharp.WebApi.V2.Models.GuildLog`
  - `Joined` in `Gw2Sharp.WebApi.V2.Models.GuildMember`
  - `Started` and `Ended` in `Gw2Sharp.WebApi.V2.Models.GuildTeamGame`
  - `ExpiresAt` and `IssuedAt` in `Gw2Sharp.WebApi.V2.Models.SubTokenInfo`
- **Breaking:** The following arguments have had their types changed from `DateTime` to `DateTimeOffset`:
  - `expire` in `Gw2Sharp.WebApi.V2.Clients.ICreateSubtokenClient.Expires()`
  - `expire` in `Gw2Sharp.WebApi.V2.Clients.CreateSubtokenClient.Expires()`

---

## 0.5.0
### Endpoints
- Add render service which can be found under `IGw2WebApiClient.Render` (right next to `IGw2WebApiClient.V2`) ([#6](https://github.com/Archomeda/Gw2Sharp/issues/6))
- Add `RenderUrl` type to directly access download methods from the render client
- Add `/v2/novelties`
- Add `/v2/outfits`
- Add `/v2/pets`
- Add `/v2/professions`

### Caching
- Add `ArchiveCacheMethod` to support caching large blobs of data in a ZIP archive on disk (e.g. images from render)

### Fixes
- **Breaking:** Fix types of `Coordinates2.X` and `Coordinates2.Y` from int to double

### Refactoring
- **Breaking:** All web API v2 properties that are URLs have been changed from type `string` to type `Gw2Sharp.WebApi.RenderUrl`
- **Breaking:** `Gw2Sharp.WebApi.Gw2WebApiClient` can no longer be instantiated directly; use `Gw2Sharp.Gw2Client` instead
- **Breaking:** `Gw2Sharp.WebApi.IConnection` and `Gw2Sharp.WebApi.Connection` have been moved into the root `Gw2Sharp` namespace
- **Breaking:** `Gw2Sharp.WebApi.V2.Models.Maps.MapType` and `Gw2Sharp.WebApi.V2.Models.Coordinates2` have been moved into the `Gw2Sharp.Models` namespace
- **Breaking:** A bunch of overloaded constructors of `Gw2Sharp.Connection` have been simplified into one constructor with optional parameters
- **Breaking:** `Gw2Sharp.IConnection.RequestAsync` has its signature changed to include a parameter of type `Gw2Sharp.IGw2Client`
- **Breaking:** All custom JSON converters inside the `Gw2Sharp.WebApi.V2.Models.Converters` namespace have been moved into the `Gw2Sharp.Json.Converters` namespace
- **Breaking:** All web API clients no longer have public constructors; access them through `Gw2Sharp.Gw2Client` instead

### Deprecation removals
- Following up on version 0.4.0, the methods `ICacheMethod.HasAsync`, `ICacheMethod.GetAsync` and `ICacheMethod.GetOrNullAsync` have been removed

---

## 0.4.1
### Fixes
- Fix memory cache garbage collection with keys other than a string causing InvalidCastExceptions

## 0.4.0
### Endpoints
- Add `/v2/account/novelties`
- Add `/v2/characters/:id/quests`
- Add `/v2/mailcarriers`
- Add `/v2/mapchests`
- Add `/v2/maps`
- Add `/v2/masteries`
- Add `/v2/materials`
- Add `/v2/minis`
- Add `/v2/mounts/skills`
- Add `/v2/mounts/types`
- Add `/v2/worldbosses`
- Add `IColorsClient.Fur` (`/v2/colors`)

### Fixes
- Fix `ApiEnum<T>.IsUnknown` detection when the API uses snake_case or camelCase enums instead of PascalCase
- Add HTTP 401 responses as alias for `AuthorizationRequiredException`
- Add `Invalid access token` error response as alias for `InvalidAccessTokenException`
- Authorization error responses are now matched case insensitive to their exception counterpart
- Prevent possible race condition and infinite loop when collecting garbage from old cache items ([#3](https://github.com/Archomeda/Gw2Sharp/issues/3))

### Refactoring
- **Breaking:** Various endpoint clients with child endpoint clients and/or extra parameters have had their virtual property setters removed; you can still override the property for customization however
  (reason: it's discouraged to call virtual methods or set virtual properties from a constructor in a non-sealed class)
- **Breaking:** `IGuildIdLogClient.ParamSince` and its implementation `GuildIdLogClient.ParamSince` are no longer virtual and no longer have a public setter to follow convention of e.g. `CreateSubtokenClient` (use `IGuildIdLogClient.Since(int? since)` to set this parameter with the fluent design pattern)
- **Breaking:** Since the settings in `IConnection` are only used interally, the `.Connection` property of `IGw2WebApiClient`, `IGw2WebApiV2Client` and all endpoint clients have been either removed or are now marked as internal ([#4](https://github.com/Archomeda/Gw2Sharp/issues/4))
  (if you still want to keep track of these settings, you should keep a reference to the instance yourself)
- Most `Connection` properties have a public setter to allow changes after object creation
- **Breaking:** `ICacheMethod` and its implementations received a small clean-up due to it being an overengineered interface (all deprecations will be fully removed in 0.5.0+):
  - `HasAsync` is marked as deprecated and is unused in Gw2Sharp from now on
  - `GetAsync` is marked as deprecated and is unused in Gw2Sharp from now on
  - `GetOrNullAsync` is marked as deprecated and is renamed to `TryGetAsync` (functionality is the same)

---

## 0.3.1
### Fixes
- Don't leak cached authenticated requests ([#1](https://github.com/Archomeda/Gw2Sharp/issues/1))
- Use ConcurrentDictionary for MemoryCacheMethod for thread-safety ([#2](https://github.com/Archomeda/Gw2Sharp/issues/2))

## 0.3.0
### Endpoints
- **Breaking:** Update `/v2/account` and all subendpoints to a minimum schema version of `2019-02-21T00:00:00.000Z`
- **Breaking:** Update `/v2/characters` and all subendpoints to schema version `2019-02-21T00:00:00.000Z`
- Add `/v2/account/dailycrafting`
- Add `/v2/account/luck`
- Add `/v2/account/mapchests`
- Add `/v2/account/mounts/skins`
- Add `/v2/account/mounts/types`
- Add `/v2/account/worldbosses`
- Add `/v2/dailycrafting`
- Add `/v2/home/nodes`

### Features
- **Breaking:** Remove `.GetWithResponseAsync()`, `.AllWithResponseAsync()`, `.IdsWithResponseAsync()`, `.ManyWithResponseAsync()` and `.PageWithResponseAsync()` of all decendants of `IClient`.
  Response information is now returned in the `IApiV2Object.HttpResponseInfo` property of the return objects of all respective `*Async()` methods).
- Add support for the `Last-Modified` header (can be accessed in `IApiV2Object.HttpResponseInfo`)

### Refactoring
- **Breaking:** In `IPaginatedClient<TObject>`, the `PageAsync(int page, CancellationToken cancellationToken, int pageSize)` method has had its order of parameters changed to `PageAsync(int page, int pageSize, CancellationToken cancellationToken)`.

---

## 0.2.0
### Endpoints
- **Breaking:** Update `/v2/account/home/cats` to schema version `2019-03-22T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily/tomorrow` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Remove `/v2/cats` in favor of `/v2/home/cats`
- Add `/v2/createsubtoken`
- Add `/v2/tokeninfo`

---

## 0.1.0
- Test release with support for a bunch of endpoints
