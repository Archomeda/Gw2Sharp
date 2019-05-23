# Gw2Sharp History

### 0.3.0
- Add support for the `Last-Modified` header (can be accessed in `IApiV2Object.HttpResponseInfo`)
- Update `/v2/account` and all subendpoints to a minimum schema version of `2019-02-21T00:00:00.000Z`
- Update `/v2/characters` and all subendpoints to schema version `2019-02-21T00:00:00.000Z`
- Remove `.GetWithResponseAsync()`, `.AllWithResponseAsync()`, `.IdsWithResponseAsync()`, `.ManyWithResponseAsync()` and `.PageWithResponseAsync()` of all decendants of `IClient`.  
  Response information is now returned in the `IApiV2Object.HttpResponseInfo` property of the return objects of all respective `*Async()` methods).

### 0.2.0
- Add `/v2/createsubtoken`
- Add `/v2/tokeninfo`
- Update `/v2/account/home/cats` to schema version `2019-03-22T00:00:00.000Z`
- Update `/v2/achievements/daily` to schema version `2019-05-16T00:00:00.000Z`
- Update `/v2/achievements/daily/tomorrow` to schema version `2019-05-16T00:00:00.000Z`
- Remove `/v2/cats` in favor of `/v2/home/cats`

### 0.1.0
- Test release with support for a bunch of endpoints
