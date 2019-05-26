# Gw2Sharp History

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
