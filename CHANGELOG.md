# Gw2Sharp History

## 2.0.0
This version includes breaking changes.

### Fixes
- **Breaking:** The following enums have moved namespaces from the root Gw2Sharp into their proper namespaces ([#93](https://github.com/Archomeda/Gw2Sharp/pull/93)):
  - `Gw2Sharp.WebApi.Caching.CacheItemStatus`
  - `Gw2Sharp.WebApi.Caching.CacheItemType`
  - `Gw2Sharp.WebApi.Models.ComboFieldType`
  - `Gw2Sharp.WebApi.Models.ComboFinisherType`
  - `Gw2Sharp.WebApi.Models.ItemEquipmentLocationType`
  - `Gw2Sharp.WebApi.Models.ProfessionFlag`
  - `Gw2Sharp.WebApi.Models.ProfessionTrainingCategory`
  - `Gw2Sharp.WebApi.Models.ProfessionTrainingTrackStepType`
  - `Gw2Sharp.WebApi.Models.ProfessionWeaponFlag`
  - `Gw2Sharp.WebApi.Models.PvpSeasonDivisionFlag`
  - `Gw2Sharp.WebApi.Models.PvpSeasonLeaderboardScoringOrder`
  - `Gw2Sharp.WebApi.Models.PvpSeasonLeaderboardScoringType`
  - `Gw2Sharp.WebApi.Models.PvpSeasonLeaderboardSettingsTierType`
  - `Gw2Sharp.WebApi.Models.RaidWingEventType`
  - `Gw2Sharp.WebApi.Models.SkillFlag`
  - `Gw2Sharp.WebApi.Models.SkillType`
  - `Gw2Sharp.WebApi.Models.SkinFlag`
  - `Gw2Sharp.WebApi.Models.StoryFlag`

### Deprecation removals
- Following up on version 1.1.0, `EquipmentPvp` has been removed from `Gw2Sharp.WebApi.V2.Models.Character` ([#92](https://github.com/Archomeda/Gw2Sharp/pull/92))

---

## 1.7.4 (28 February 2023)
This release fixes some of the high priority bugs.

### Endpoints
- Add missing End of Dragons item type `JadeTechModule` as `Gw2Sharp.WebApi.V2.Models.ItemJadeTechModule` for pattern matching ([#127](https://github.com/Archomeda/Gw2Sharp/pull/127) by [@dlamkins](https://github.com/dlamkins))
- Add missing End of Dragons item type `PowerCore` as `Gw2Sharp.WebApi.V2.Models.ItemPowerCore` for pattern matching ([#127](https://github.com/Archomeda/Gw2Sharp/pull/127) by [@dlamkins](https://github.com/dlamkins))

### Miscellaneous
- Fix an ArgumentException when embedding Gw2Sharp in a single executable ([#125](https://github.com/Archomeda/Gw2Sharp/pull/125) by [@Taschenbuch](https://github.com/Taschenbuch))
- Fix docs to clarify that the `/v2/account/progression` endpoint also requires the unlcoks permission ([#124](https://github.com/Archomeda/Gw2Sharp/pull/124) by [@Taschenbuch](https://github.com/Taschenbuch))
- From now on, every missing class type that's used for polymorphic deserializing will not throw a JsonException with the message "Unsupported type \<type\>" anymore (for example with item types) ([#120](https://github.com/Archomeda/Gw2Sharp/issues/120), [#128](https://github.com/Archomeda/Gw2Sharp/pull/128))

## 1.7.3 (14 July 2022)
This is a small bugfix for a typo in the `/v2/raids` endpoint, causing a 404.

### Endpoints
- Fix `/v2/raids` endpoint returning a 404 ([#122](https://github.com/Archomeda/Gw2Sharp/issues/122), [#123](https://github.com/Archomeda/Gw2Sharp/pull/123))

## 1.7.2 (22 May 2022)
This is a small bugfix for the caching component.

### Caching
- Fix separate item caching for bulk endpoints where the request headers that may produce different responses, were not taken into account ([#119](https://github.com/Archomeda/Gw2Sharp/issues/119), [#121](https://github.com/Archomeda/Gw2Sharp/pull/121))

## 1.7.1 (9 April 2022)
This includes a small fix for the Icon property on skills, which can be null.

### Endpoints
- Change `Icon` property on `Gw2Sharp.WebApi.V2.Models.Skill` to be nullable ([#118](https://github.com/Archomeda/Gw2Sharp/pull/118) by [@dlamkins](https://github.com/dlamkins))

## 1.7.0 (6 February 2022)
This release is a small feature update for End of Dragons and a forgotten name property in the equipment tab response.

### Endpoints
- Add `Name` property to `Gw2Sharp.WebApi.V2.Models.CharacterEquipmentTabSlot` ([#115](https://github.com/Archomeda/Gw2Sharp/pull/115))

### Mumble Link
- Add support for the Skiff and the Siege Turtle mount enums ([#114](https://github.com/Archomeda/Gw2Sharp/pull/114) by [@TheMrMilchmann](https://github.com/TheMrMilchmann))

### Miscellaneous
- Testing against .NET Core 2.1 has been removed as this version has been end of life for quite some time now. Instead, testing against .NET 6 has now been added. This doesn't have any impact for any consumers of Gw2Sharp. ([#111](https://github.com/Archomeda/Gw2Sharp/pull/111))

---

## 1.6.1 (30 December 2021)
This is a hotfix release that actually includes the Mumble Link additions as listed in v1.6.0.

## 1.6.0 (30 December 2021)
This release includes support for a couple of additional customizations:
- Ability to change the API hostname(s) in case you want to run a proxy API server (see [the documentation](https://archomeda.github.io/Gw2Sharp/master/guides/proxy.html) for more information)
- Ability to change the Mumble Link reader for mocking, or to use a different method and/or source for Mumble Link

### HTTP
- Add `ApiBaseUrl` and `RenderBaseUrl` properties to `Gw2Sharp.IConnection` ([#108](https://github.com/Archomeda/Gw2Sharp/issues/108), [#109](https://github.com/Archomeda/Gw2Sharp/pull/109))

### Mumble Link
- Add support for custom Mumble Link readers ([#110](https://github.com/Archomeda/Gw2Sharp/pull/110))
  -  Add `MumbleClientReaderFactory` property to `Gw2Sharp.IConnection` that constructs a new Mumble Link reader that implements `Gw2Sharp.Mumble.IGw2MumbleClientReader`
  - .NET 5 and up: `SupportedOSPlatformAttribute`s have been moved around to support these changes
  - The following structs that are used in the reader have been made public: `Gw2Sharp.Mumble.Gw2LinkedMem`, `Gw2Sharp.Mumble.Gw2Context` and `Gw2Sharp.Mumble.Models.UiState`

---

## 1.5.0 (13 November 2021)
This release contains one small addition to make changing the request timeout easier.

### Generic
- Add `RequestTimeout` property to `Gw2Sharp.IConnection` ([#97](https://github.com/Archomeda/Gw2Sharp/issues/97), [#107](https://github.com/Archomeda/Gw2Sharp/pull/107))

---

## 1.4.0 (28 September 2021)
This release focuses on the new account progression addition, introduced on 28 September 2021.

### Endpoints
- Add `/v2/account/progression` ([#101](https://github.com/Archomeda/Gw2Sharp/issues/101), [#103](https://github.com/Archomeda/Gw2Sharp/pull/103))
- Mark `/v2/account/luck` as deprecated (progression is the replacement) ([#102](https://github.com/Archomeda/Gw2Sharp/issues/102), [#103](https://github.com/Archomeda/Gw2Sharp/pull/103))

*Note: All deprecations in version 1.x will be removed in version 2.0. Make sure that you update the references.*

---

## 1.3.0 (4 September 2021)
This release includes a single addition to the WvW match endpoints, which is the ability to request a match by world id for the following endpoints:
- `/v2/wvw/matches`
- `/v2/wvw/matches/overview`
- `/v2/wvw/matches/scores`
- `/v2/wvw/matches/stats`

---

## 1.2.0 (17 July 2021)
This release focuses on the new legendary armory addition, introduced in the game on 13 July 2021, along with some minor bug fixes.

### Endpoints
- Add `/v2/account/legendaryarmory` ([#86](https://github.com/Archomeda/Gw2Sharp/pull/86))
- Add `/v2/legendaryarmory` ([#86](https://github.com/Archomeda/Gw2Sharp/pull/86))
- Apply schema changes of 2021-07-15 that updates the equipment location type ([`Gw2Sharp.WebApi.V2.Models.ItemEquipmentLocationType`](https://archomeda.github.io/Gw2Sharp/master/api/Gw2Sharp.WebApi.V2.Models.ItemEquipmentLocationType.html)) to include `EquippedFromLegendaryArmory` and `LegendaryArmory` for `/v2/characters`, `/v2/characters/:id`, `/v2/characters/:id/equipment` and `/v2/characters/:id/equipmenttabs` ([#91](https://github.com/Archomeda/Gw2Sharp/pull/91))

### Fixes
- Due to an oversight, [`Gw2Sharp.WebApi.V2.Clients.CharactersIdClient`](https://archomeda.github.io/Gw2Sharp/master/api/Gw2Sharp.WebApi.V2.Clients.CharactersIdClient.html) didn't properly expose `EquipmentPvp` that was made available with the previous schema update, which is corrected along with the latest schema update ([#91](https://github.com/Archomeda/Gw2Sharp/pull/91))
- Failing responses that don't have a JSON body now have the correct exception type based on the HTTP status code (was always `UnexpectedStatusException` before, instead of e.g. `ServerErrorException` for a 500) ([#89](https://github.com/Archomeda/Gw2Sharp/pull/89))
- The version reported in the user agent is now the correct version (file version instead of assembly version) ([#88](https://github.com/Archomeda/Gw2Sharp/pull/88))

### Miscellaneous
- .NET 5 is explicitly targeted in order to make use of the cross-platform attributes ([#90](https://github.com/Archomeda/Gw2Sharp/pull/90))
  - We are using this to warn users when accessing the Mumble Link client on a non-Windows platform (this is only supported when your project targets .NET 5 or higher)

---

## 1.1.0 (8 April 2021)
This release applies the schema changes of 2021-04-06, which has moved the PvP equipment details to the proper equipment tabs information.

### Endpoints
- Move `EquipmentPvp` from `Gw2Sharp.WebApi.V2.Models.Character` to `Gw2Sharp.WebApi.V2.Models.CharacterEquipmentTabSlot` ([#85](https://github.com/Archomeda/Gw2Sharp/issues/85)).
  - This deprecates `EquipmentPvp` from `Gw2Sharp.WebApi.V2.Models.Character` and will finally be removed from Gw2Sharp starting from version 2.0
  - This makes `EquipmentPvp` also available under the `/v2/characters/:id/equipmenttabs` sub-endpoint, which can be reached from [`Gw2Client.WebApi.V2.Characters[id].EquipmentTabs`](https://archomeda.github.io/Gw2Sharp/master/api/Gw2Sharp.WebApi.V2.Clients.CharactersIdEquipmentTabsClient.html)

---

## 1.0.0 (1 January 2021)
*Gw2Sharp can now be considered feature complete.*

Happy new year everyone 🎆  
Let's celebrate 2021 with the first non-prerelease version of Gw2Sharp!

Despite this being a major version increment, there have been no public facing code changes compared to 0.12.0; your code should still compile without any issues.

Given that we have reached version 1, I'm changing the way how the versioning works.  
Previously, when Gw2Sharp was still in version 0.x.y, any breaking change would increment the minor number and any non-breaking change would increment the patch number.  
Now, starting with version 1, Gw2Sharp will follow semver properly.
Breaking changes will increment the major version.
Non-breaking additions will increment the minor version.
Non-breaking fixes will increment the patch version.

### Dependencies
- System.Text.Json has been updated to 5.0.0 with some additional internal changes to support the transition from 4.7.1

---

## 0.12.0 (22 December 2020)
*After 2 years of development, this version marks a milestone for Gw2Sharp.*

It is now feature complete, with thanks to [@werdes](https://github.com/werdes) for setting up WvW support that I have postponed for quite a while.

What does this mean for the future for Gw2Sharp?
Well, there is at least one additional thing I still want to finish, and that's updating the System.Text.Json dependency to version 5.
Once I've finished that, Gw2Sharp 1.0.0 is around the corner, and it's pretty much done until ArenaNet adds additional endpoints or makes additional changes to the API.

Besides feature completing Gw2Sharp, this version also includes a major update regarding caching support as mentioned in 0.11.1.
This is a breaking change, but it will make caching more reliable ([#71](https://github.com/Archomeda/Gw2Sharp/issues/71)).
All interfaces and built-in caching classes have been overhauled.
In short, the focus was to only support strings and raw byte arrays, instead of generic types that have to be converted back and forth between C# objects and JSON strings.

Ironically, while the classes themselves have had their generic types removed, the cache objects are actually more generic since they support the raw responses instead of being bound to C# types.

**Heads up:** If you've been using the `ArchiveCacheMethod`, keep in mind that 0.12.0 uses a new file structure and will fully clear the archive if it detects that the archive isn't in the structure it expects it to be.
If you decide to revert to an older Gw2Sharp version, you may experience exceptions if you don't delete the archive manually before using it.
Please do not report those issues as they will not be worked on.

*If you haven't implemented your own caching method(s), you should have no issues updating.*

### Caching
- **Breaking:** `Gw2Sharp.WebApi.Caching.CacheItem<T>` has been removed
- **Breaking:** `Gw2Sharp.WebApi.Caching.CacheItem` no longer implements `IEquatable<CacheItem>` since it's no longer used internally
- **Breaking:** Since the generic version of `Gw2Sharp.WebApi.Caching.CacheItem` has been removed, the actual data can now be retrieved with the properties `RawItem` or `StringItem`, depending if it's a raw byte array or a string (accessing the wrong property will throw an `InvalidOperationException`)
- `Gw2Sharp.WebApi.Caching.CacheItem` has additional properties `Status`, `Type` and `StatusCode`
- The enums `Gw2Sharp.WebApi.Caching.CacheItemStatus` and `Gw2Sharp.WebApi.Caching.CacheItemType` have been added to support the previous mentioned properties
- **Breaking:** In `Gw2Sharp.WebApi.Caching.ICacheMethod` (and their derivatives `BaseCacheMethod`, `ArchiveCacheMethod`, `MemoryCacheMethod` and `NullCacheMethod`), the methods `TryGetAsync`, `SetAsync`, `SetManyAsync`, `GetOrUpdateAsync` and `GetOrUpdateManyAsync` have been changed to non-generic versions of themselves and `CacheItem`
- **Breaking:** In `Gw2Sharp.WebApi.Caching.ICacheMethod` (and their derivatives `BaseCacheMethod`, `ArchiveCacheMethod`, `MemoryCacheMethod` and `NullCacheMethod`), the methods `SetAsync`, `GetOrUpdateAsync` and `GetOrUpdateManyAsync` have had their signature changed to strip out redundant parameters that are now included in `CacheItem`
- **Breaking:** The internal ZIP file structure used in `Gw2Sharp.WebApi.Caching.ArchiveCacheMethod` has been changed to support the caching changes, bumping it from no versioning to version 1

### HTTP
- **Breaking:** The constant `CACHE_STATE_HEADER` in `Gw2Sharp.WebApi.Http.HttpResponseInfo` has been removed in favor of having a dedicated cache state property on various classes, instead of injecting it through a custom Gw2Sharp header
- **Breaking:** `Gw2Sharp.WebApi.Http.IHttpResponseStream` and `Gw2Sharp.WebApi.Http.IWebApiResponse` have the additional property `CacheState`
- **Breaking:** The constructors of `Gw2Sharp.WebApi.Http.HttpResponseInfo`, `Gw2Sharp.WebApi.Http.HttpResponseStream`, `Gw2Sharp.WebApi.Http.WebApiResponse` and `Gw2Sharp.WebApi.V2.ApiV2HttpResponseInfo` have been modified to accept the `CacheState` parameter

### Endpoints
- Add `/v2/wvw/abilities` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80) by [@werdes](https://github.com/werdes))
- Add `/v2/wvw/matches` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80) by [@werdes](https://github.com/werdes))
- Add `/v2/wvw/matches/overview` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80))
- Add `/v2/wvw/matches/scores` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80))
- Add `/v2/wvw/matches/stats` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80))
- Add `/v2/wvw/objectives` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80) by [@werdes](https://github.com/werdes))
- Add `/v2/wvw/ranks` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80) by [@werdes](https://github.com/werdes))
- Add `/v2/wvw/upgrades` ([#80](https://github.com/Archomeda/Gw2Sharp/pull/80) by [@werdes](https://github.com/werdes))
- Add `AttributeAdjustment` property to various item related models (`Gw2Sharp.WebApi.V2.Models.ItemArmorDetails`, `Gw2Sharp.WebApi.V2.Models.ItemBackDetails`, `Gw2Sharp.WebApi.V2.Models.ItemTrinketDetails`, `Gw2Sharp.WebApi.V2.Models.ItemUpgradeComponentDetails`, `Gw2Sharp.WebApi.V2.Models.ItemWeaponDetails`) ([#70](https://github.com/Archomeda/Gw2Sharp/issues/70), [#84](https://github.com/Archomeda/Gw2Sharp/pull/84))

---

## 0.11.1 (29 August 2020)
### Caching
- Fix caching with an archive backing file (`ArchiveCacheMethod`) where it cannot (de)serialize the data ([#72](https://github.com/Archomeda/Gw2Sharp/pull/72))

### Fixes
- Fix `LegendType` to start with 1 instead of 14 ([#73](https://github.com/Archomeda/Gw2Sharp/pull/73))

### Upcoming breaking changes
While the `ArchiveCacheMethod` should be fixed for now, the upcoming version 0.12.0 will introduce an overhaul for all caching methods that will make them more reliable.
This patch update should be regarded as an intermediate fix before that happens, without introducing breaking changes.

## 0.11.0 (9 August 2020)
This release includes the most breaking changes in Gw2Sharp so far in order to support middleware, which is a major change in how Gw2Sharp handles requests.
If you're only using the surface API in Gw2Sharp, the impact will be very low.
However, if you've been implementing some of the interfaces yourself in order to change Gw2Sharp's functionality, please review the changes listed for this release below to see how much you've been impacted.

### Middleware
By default, three middleware classes are enabled: `CacheMiddleware`, `RequestSplitterMiddleware` and `ExceptionMiddleware`.
You can configure the middleware used when creating a `Connection` through the `Middleware` property.
This property is an `IList`, and the order of execution follows the order of the list.
This means that the first middleware that's in the list will be executed first, and the last middleware will be executed last.

For more information, please check the [middleware documentation](https://archomeda.github.io/Gw2Sharp/master/guides/middleware.html).

### Caching
- **Breaking:** `Gw2Sharp.WebApi.Caching.ICacheMethod` (and its implementers `BaseCacheMethod`, `ArchiveCacheMethod`, `MemoryCacheMethod`) and `Gw2Sharp.WebApi.Caching.CacheItem` have had their keys changed from the `object` type to the `string` type
- `Gw2Sharp.WebApi.Http.HttpResponseInfo` (that is set on all API return types as the `HttpResponseInfo` property) now includes an additional property called `CacheState` that indicates whether the request was served from cache or from the live API server (please be aware of the [current limitations](https://archomeda.github.io/Gw2Sharp/master/guides/response-info.html#checking-the-response-info)).

### Endpoints
- **Breaking:** `Gw2Sharp.WebApi.V2.Models.Profession.SkillsByPalette` is now using a `IReadOnlyDictionary<int, int>` instead of `IDictionary<int, int>`
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.BaseEndpointClient` has had its generic parameter removed as it's no longer necessary
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.IEndpointClient` has been changed to better expose the endpoint metadata (all its implementers, basically all endpoint clients, have been updated to reflect these changes as well)
- `Gw2Sharp.WebApi.V2.Clients.EndpointBulkIdNameAttribute` has been extended to support a different id name for the object in case it doesn't equal the id name of the query parameter (this is e.g. used in the middleware to split and merge responses and/or caching)
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.EndpointPathParameterAttribute` has been renamed to `EndpointQueryParameterAttribute` to indicate it's actually a query parameter and not a URL path
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.IEndpointClientImplementation` and its implementer `EndpointClientImplementation` has been removed in favor of middleware
- **Breaking:** All custom request exceptions listed in the `Gw2Sharp.WebApi.Http` namespace have been moved into the `Gw2Sharp.WebApi.Exceptions` namespace
- All custom request exceptions have had their `ISerializable` implementation removed because it's too tedious to maintain for now
- Two new types of bad requests have been added in `Gw2Sharp.WebApi.Exceptions`:
  - `ListTooLongException`: This will be thrown whenever the API request contains too many ids for the request to complete (this may happen when the `RequestSplitterMiddleware` isn't used)
  - `PageOutOfRangeException`: The will be thrown whenever a paged API request is done for a page that doesn't exist, a.k.a. is out of range
- Update `Gw2Sharp.WebApi.V2.Pvp.Seasons[id].Leaderboards[board][region]` to support pagination ([#55](https://github.com/Archomeda/Gw2Sharp/issues/55))

### Fixes
- Fix possible memory leak when using the archive memory cache in combination with binary data (a `MemoryStream` was not being disposed)
- Fix `KeyNotFoundException` when performing a many request with at least one (but not all) invalid id ([#65](https://github.com/Archomeda/Gw2Sharp/issues/65), [#66](https://github.com/Archomeda/Gw2Sharp/pull/66))
- Fix `LegendType` to start with 14 instead of 13 ([#63](https://github.com/Archomeda/Gw2Sharp/issues/63))
- Fail early when an access token is incorrectly formatted by throwing an `ArgumentException` during constructing of the `Connection` object, and when setting it through the `Connection.AccessToken` property ([#62](https://github.com/Archomeda/Gw2Sharp/issues/62))

### Refactoring
- **Breaking:** `Gw2Sharp.IConnection` no longer has `RequestAsync(...)` since this functionality has been rewritten to support middleware
- **Breaking:** `Gw2Sharp.IConnection` now has the property `IList<Gw2Sharp.WebApi.Middleware.IWebApiMiddleware>` to configure the middleware
- **Breaking:** `Gw2Sharp.WebApi.Http.HttpResponseInfo` has had its `RawRequestHeaders` property removed
- **Breaking:** `Gw2Sharp.WebApi.Http.IHttpRequest` has been renamed to `IWebApiRequest`, its properties have been changed and moved into the property `Options` and the new method `ExecuteAsync(...)` has been added
- **Breaking:** Following its interface, `Gw2Sharp.WebApi.Http.HttpRequest` has been renamed to `WebApiRequest` and its functionality has been adopted to the changes in the interface as well
- **Breaking:** `Gw2Sharp.WebApi.Http.IHttpResponse` has been renamed to `IWebApiResponse` and no longer contains `RequestHeaders`, while `ResponseHeaders` is no longer read-only (to allow middleware to change them if necessary) and has the additional method `Copy` (to allow middleware to copy a few properties by value into a new response object)
- **Breaking:** Following its interface, `Gw2Sharp.WebApi.Http.HttpResponse` has been renamed to `WebApiResponse` and its functionality has been adopted to the changes in the interface as well
- **Breaking**, but minimal impact unless you've been using some of the "public" internals provided by Gw2Sharp in your application:
  - The following structs have been made readonly: `Gw2Sharp.Models.Coordinates2`, `Gw2Sharp.Models.Coordinates3`, `Gw2Sharp.Models.Size`
  - All chat link structs that were in the namespace `Gw2Sharp.ChatLinks.Structs` have been moved to `Gw2Sharp.ChatLinks.Internal` to clarify that they are for internal use only
  - The `Gw2Sharp.Json.Converters.CompactMapConverter` that's used for endpoints that return objects with skill palettes has been changed to deserialize to `IReadOnlyDictionary<K, V>` instead of `IDictionary<K, V>`
- A bunch of internal code changes to conform ReSharper and Microsoft.CodeAnalysis.FxCopAnalyzers
- All methods that compare strings, parse strings or create strings from other types have been updated to make sure that they ignore the system locale
- Mount type 10 in Mumble Link doesn't redirect to `MountType.None` anymore ([#64](https://github.com/Archomeda/Gw2Sharp/issues/64))

---

## 0.10.0 (24 May 2020)
### Endpoints
- Add `/v2/skins`
- Add `/v2/specializations`
- Add `/v2/stories`
- Add `/v2/stories/seasons`
- Add `/v2/titles`
- Add `/v2/traits`
- Add `/v2/worlds`

### Refactoring
- **Breaking:** `Gw2Sharp.Models.MountSkinDyeSlot` has been renamed to `Gw2Sharp.Models.SkinDyeSlot`
- **Breaking:** `Gw2Sharp.WebApi.V2.Clients.ILocalizedClient` no longer accepts the object type as generic type parameter; it's now just an interface without any type parameters ([#57](https://github.com/Archomeda/Gw2Sharp/issues/57), [#61](https://github.com/Archomeda/Gw2Sharp/pull/61))
- **Breaking:** Some internal reworkings of how the various endpoint clients are implemented; this includes the removal of the public `Gw2Sharp.IClient` interface ([#61](https://github.com/Archomeda/Gw2Sharp/pull/61))

### Deprecation removals
- Following up on version 0.9.5, the enum value `Gw2Sharp.WebApi.V2.Models.SkillWeaponType.Harpoon` has been removed in favor of `Spear`

---

## 0.9.6 (28 April 2020)
### Services
- Update MumbleLink to support new features ([#58](https://github.com/Archomeda/Gw2Sharp/issues/58), [#59](https://github.com/Archomeda/Gw2Sharp/pull/59)):
  - Process id
  - Mount
  - UI states: IsInCombat
- Add support for custom MumbleLink names through `IGw2MumbleClient[name]` (see documentation for more details)

## 0.9.5 (18 April 2020)
### Endpoints
- Add the following missing properties in `Gw2Sharp.WebApi.V2.Models.Skill`:
  - `Specialization`
  - `DualAttunement`
  - `SubSkills`
- Change the following properties from `int` to `double`:
  - `Gw2Sharp.WebApi.V2.Models.SkillFactComboFinisher.Percent`
  - `Gw2Sharp.WebApi.V2.Models.SkillFactPercent.Percent`
  - `Gw2Sharp.WebApi.V2.Models.SkillFactRecharge.Value`
- Add missing property `Value` in `Gw2Sharp.WebApi.V2.Models.SkillFactPercent` (although this seems to be a bug in the API)
- Deprecate `Gw2Sharp.WebApi.V2.Models.SkillWeaponType.Harpoon` in favor of `Spear` (still no consistency between harpoons, spears, harpoon guns and spear guns)
- Add missing enum `None` in `Gw2Sharp.WebApi.V2.Models.AttributeType` (which is apparently used for skills that apply barrier)
- Add missing enums `Toolbelt` and `Transform1` in `Gw2Sharp.WebApi.V2.Models.SkillSlot`
- Add missing enum `Transform` in `Gw2Sharp.WebApi.V2.Models.SkillType`

## 0.9.4 (18 April 2020)
### Fixes
- Add missing skill fact type `StunBreak` as `Gw2Sharp.WebApi.V2.Models.SkillFactStunBreak` for pattern matching
- Fix parsing `Cache-Control` response headers where it would fail if the value is surrounded with quotes

## 0.9.3 (29 March 2020)
### Services
- Exposed the raw JSON Mumble Link identity as `IGw2MumbleClient.RawIdentity`

### Fixes
- When the Mumble Link identity contains an invalid JSON, it will no longer cause Gw2Sharp to throw a JsonException (this can happen when running multiple instances of Guild Wars 2 at the same time)

## 0.9.2 (26 March 2020)
### Fixes
- Setting a custom user agent now properly sets a space inbetween that and the one set by Gw2Sharp

## 0.9.1 (23 March 2020)
### Endpoints
- Add missing enum `2v2Ranked` (as `TwoVTwoRanked`) in `Gw2Sharp.WebApi.V2.Models.PvpRatingType` ([#53](https://github.com/Archomeda/Gw2Sharp/pull/53))

### Fixes
- Improve enum deserialization performance ([#52](https://github.com/Archomeda/Gw2Sharp/issues/52), [#54](https://github.com/Archomeda/Gw2Sharp/pull/54))

## 0.9.0 (21 March 2020)
For this release, Gw2Sharp has swapped its JSON dependency from Newtonsoft.Json to System.Text.Json. This means that you can expect a performance increase ([#48](https://github.com/Archomeda/Gw2Sharp/pull/48)).

### Services
- Various web API endpoints have been extended to support enums as ids with automatic conversion to their API id type ([#40](https://github.com/Archomeda/Gw2Sharp/issues/40), [#41](https://github.com/Archomeda/Gw2Sharp/pull/41))
  - To support this, the interface `Gw2Sharp.WebApi.V2.Clients.IBulkAliasExpandableClient` has been added
  - `Gw2Sharp.WebApi.V2.Clients.ILegendsClient` now implements `Gw2Sharp.WebApi.V2.Clients.IBulkAliasExpandableClient` and supports requesting `GetAsync` and `ManyAsync` with `Gw2Sharp.Models.LegendType` as id type
  - `Gw2Sharp.WebApi.V2.Clients.IProfessionClient` now implements `Gw2Sharp.WebApi.V2.Clients.IBulkAliasExpandableClient` and supports requesting `GetAsync` and `ManyAsync` with `Gw2Sharp.Models.ProfessionType` as id type
  - `Gw2Sharp.WebApi.V2.Clients.IRaceClient` now implements `Gw2Sharp.WebApi.V2.Clients.IBulkAliasExpandableClient` and supports requesting `GetAsync` and `ManyAsync` with `Gw2Sharp.Models.RaceType` as id type
- **Breaking:** The `Race` property in the Mumble Client is now of type `RaceType` instead of `string` ([#40](https://github.com/Archomeda/Gw2Sharp/issues/40), [#41](https://github.com/Archomeda/Gw2Sharp/pull/41))
- Repeatedly requesting Mumble identity fields (or just requesting multiple) should be a bit faster now ([#39](https://github.com/Archomeda/Gw2Sharp/issues/39), [#42](https://github.com/Archomeda/Gw2Sharp/pull/42), [#48](https://github.com/Archomeda/Gw2Sharp/pull/48), [#50](https://github.com/Archomeda/Gw2Sharp/pull/50))

### Refactoring
- **Breaking:** `Gw2Sharp.Models.Legend` has been renamed to `Gw2Sharp.Models.LegendType` ([#40](https://github.com/Archomeda/Gw2Sharp/issues/40), [#41](https://github.com/Archomeda/Gw2Sharp/pull/41))
- **Breaking:** `Gw2Sharp.Models.Profession` has been renamed to `Gw2Sharp.Models.ProfessionType` ([#40](https://github.com/Archomeda/Gw2Sharp/issues/40), [#41](https://github.com/Archomeda/Gw2Sharp/pull/41))
- `Gw2Sharp.Mumble.Models.Race` has been renamed to `Gw2Sharp.Models.RaceType` and is now public instead of internal ([#40](https://github.com/Archomeda/Gw2Sharp/issues/40), [#41](https://github.com/Archomeda/Gw2Sharp/pull/41))

### Miscellaneous
- Source Link is now supported ([#46](https://github.com/Archomeda/Gw2Sharp/pull/46))

### Deprecation removals
- Following up on version 0.8.0, the method `Gw2Sharp.WebApi.Caching.ICacheMethod.FlushAsync` has been removed in favor of `ClearAsync` ([#31](https://github.com/Archomeda/Gw2Sharp/issues/31), [#44](https://github.com/Archomeda/Gw2Sharp/pull/44))
- Following up on version 0.8.0, the following pre-template APIs have been removed ([#45](https://github.com/Archomeda/Gw2Sharp/pull/45)):
  - `/v2/characters/:id/skills`
  - `/v2/characters/:id/specializations`

---

## 0.8.2 (24 February 2020)
### Fixes
- Fix API enum comparison with different character casings ([#36](https://github.com/Archomeda/Gw2Sharp/pull/36))

## 0.8.1 (20 February 2020)
### Fixes
- Fix struct size when creating the Mumble Link memory mapped file ([#35](https://github.com/Archomeda/Gw2Sharp/pull/35))
  - It was initialized with a struct size that was too small for Guild Wars 2 to write to, causing funky stuff

## 0.8.0 (20 February 2020)
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

## 0.7.4 (6 November 2019)
### Services
- Chat link parsing and rendering is now supported ([#23](https://github.com/Archomeda/Gw2Sharp/issues/23), [#24](https://github.com/Archomeda/Gw2Sharp/pull/24))

## 0.7.3 (21 October 2019)
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

## 0.7.1 (3 September 2019)
### Services
- Add Mumble Link client as `Gw2MumbleClient`, which can be accessed through `Gw2Client.Mumble` ([#7](https://github.com/Archomeda/Gw2Sharp/issues/7), [#16](https://github.com/Archomeda/Gw2Sharp/pull/16))

### Lifetime
- Because of the introduction of the `Gw2MumbleClient` that implements `IDisposable` (because it holds a reference to a memory mapped file that needs to be disposed), `Gw2Client` now implements `IDisposable` as well and should be disposed accordingly  
  **Note:** This is a breaking change if you decide to start using the Mumble Link client, because it will only create disposable resources on the first call to `.Update()` in the `Gw2MumbleClient`

### Fixes
- Fix `RecipesClient` to correctly inherit from `BaseEndpointBulkClient` instead of `BaseEndpointBulkAllClient` (`/v2/recipes` doesn't support expanding all items at once, and this was incorrectly set on the implementation, the interface was correct) ([#14](https://github.com/Archomeda/Gw2Sharp/pull/14) by [@darthmaim](https://github.com/darthmaim))

## 0.7.0 (16 August 2019)
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

## 0.6.1 (10 August 2019)
### Endpoints
- Change property `Emblem` in `Gw2Sharp.WebApi.V2.Models.Guild` to be nullable because the API might leave this property out ([#10](https://github.com/Archomeda/Gw2Sharp/issues/10))

### Fixes
- Fix default instantiations of `ApiEnum` and `ApiFlags` that might cause `InvalidCastException`s when requesting data by removing the non-generic `ApiEnum` and `ApiFlags` variants (they were only used internally for easy casting when deserializing) ([#10](https://github.com/Archomeda/Gw2Sharp/issues/10))

## 0.6.0 (9 August 2019)
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

## 0.5.0 (28 July 2019)
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

## 0.4.1 (22 June 2019)
### Fixes
- Fix memory cache garbage collection with keys other than a string causing InvalidCastExceptions

## 0.4.0 (21 June 2019)
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

## 0.3.1 (13 June 2019)
### Fixes
- Don't leak cached authenticated requests ([#1](https://github.com/Archomeda/Gw2Sharp/issues/1))
- Use ConcurrentDictionary for MemoryCacheMethod for thread-safety ([#2](https://github.com/Archomeda/Gw2Sharp/issues/2))

## 0.3.0 (27 May 2019)
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

## 0.2.0 (23 May 2019)
### Endpoints
- **Breaking:** Update `/v2/account/home/cats` to schema version `2019-03-22T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily/tomorrow` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Remove `/v2/cats` in favor of `/v2/home/cats`
- Add `/v2/createsubtoken`
- Add `/v2/tokeninfo`

---

## 0.1.0 (20 May 2019)
- Test release with support for a bunch of endpoints
