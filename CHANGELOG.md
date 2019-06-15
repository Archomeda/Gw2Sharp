# Gw2Sharp History

## 0.4.0
### Endpoints
- Add `/v2/mapchests`

### Refactoring
- **Breaking:** Various endpoint clients with child endpoint clients and/or extra parameters have had their virtual property setters removed; you can still override the property for customization however
  (reason: it's discouraged to call virtual methods or set virtual properties from a constructor in a non-sealed class)
- **Breaking:** `IGuildIdLogClient.ParamSince` and its implementation `GuildIdLogClient.ParamSince` are no longer virtual and no longer have a public setter to follow convention of e.g. `CreateSubtokenClient` (use `IGuildIdLogClient.Since(int? since)` to set this parameter with the fluent design pattern)

## 0.3.1
### Fixes
- Don't leak cached authenticated requests ([#1](https://github.com/Archomeda/Gw2Sharp/issues/1))
- Use ConcurrentDictionary for MemoryCacheMethod for thread-safety ([#2](https://github.com/Archomeda/Gw2Sharp/issues/2))

## 0.3.0
### Features
- **Breaking:** Remove `.GetWithResponseAsync()`, `.AllWithResponseAsync()`, `.IdsWithResponseAsync()`, `.ManyWithResponseAsync()` and `.PageWithResponseAsync()` of all decendants of `IClient`.
  Response information is now returned in the `IApiV2Object.HttpResponseInfo` property of the return objects of all respective `*Async()` methods).
- Add support for the `Last-Modified` header (can be accessed in `IApiV2Object.HttpResponseInfo`)

### Refactoring
- **Breaking:** In `IPaginatedClient<TObject>`, the `PageAsync(int page, CancellationToken cancellationToken, int pageSize)` method has had its order of parameters changed to `PageAsync(int page, int pageSize, CancellationToken cancellationToken)`.

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
