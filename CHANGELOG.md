# Gw2Sharp History

## 0.5.0
### Endpoints
- Add render service which can be found under `IGw2WebApiClient.Render` (right next to `IGw2WebApiClient.V2`)
- Add `/v2/novelties`

### Caching
- Add `ArchiveCacheMethod` to support caching large blobs of data in a ZIP archive on disk (e.g. images from render)

### Fixes
- **Breaking:** Fix types of `Coordinates2.X` and `Coordinates2.Y` from int to double

### Deprecation removals
- Following up on version 0.4.0, the methods `ICacheMethod.HasAsync`, `ICacheMethod.GetAsync` and `ICacheMethod.GetOrNullAsync` have been removed

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
- **Breaking:** Since the settings in `IConnection` are only used interally, the `.Connection` property of `IGw2WebApiClient`, `IGw2WebApiV2Client` and all endpoint clients have been either removed or are now marked as internal
  (if you still want to keep track of these settings, you should keep a reference to the instance yourself)
- Most `Connection` properties have a public setter to allow changes after object creation
- **Breaking:** `ICacheMethod` and its implementations received a small clean-up due to it being an overengineered interface (all deprecations will be fully removed in 0.5.0+):
  - `HasAsync` is marked as deprecated and is unused in Gw2Sharp from now on
  - `GetAsync` is marked as deprecated and is unused in Gw2Sharp from now on
  - `GetOrNullAsync` is marked as deprecated and is renamed to `TryGetAsync` (functionality is the same)

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

## 0.2.0
### Endpoints
- **Breaking:** Update `/v2/account/home/cats` to schema version `2019-03-22T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Update `/v2/achievements/daily/tomorrow` to schema version `2019-05-16T00:00:00.000Z`
- **Breaking:** Remove `/v2/cats` in favor of `/v2/home/cats`
- Add `/v2/createsubtoken`
- Add `/v2/tokeninfo`

## 0.1.0
- Test release with support for a bunch of endpoints
