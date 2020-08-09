---
uid: Guides.HttpHeaders
title: Checking the HTTP headers
---

# Checking the HTTP headers
Every response has the property `HttpResponseInfo`.
This property allows you to access the HTTP headers that the response has returned.

An example:

```cs
// Assuming you already have a client
var itemIds = await client.WebApi.V2.Items.PageAsync(0);

var cacheExpires = itemIds.HttpResponseInfo.Expires;
var cacheAge = itemIds.HttpResponseInfo.CacheMaxAge;
var itemsCount = itemIds.HttpResponseInfo.ResultCount;
var itemsTotal = itemIds.HttpResponseInfo.ResultTotal;
var pagesTotal = itemIds.HttpResponseInfo.PageTotal;
```

> [!CAUTION]
> Due to current technical limitations, performing a "many" request will only return the headers of the first item.
> These kind of requests will be performed as efficiently as possible, meaning that if the [cache middleware](xref:Guides.Middleware#cachemiddleware) is enabled, it will only request items from the live API server that are *not* available in the cache.
> Therefore, these headers might not reflect the actual response headers.

## Additional custom Gw2Sharp headers
Gw2Sharp currently adds one additional header if the [cache middleware](xref:Guides.Middleware#cachemiddleware) is enabled.
This is useful to check whether the request was served from the cache, or from the live API server.

> [!NOTE]
> This header is added by the cache middleware itself, and its value in `HttpResponseInfo` is *relatively* unaffected by the technical limitation mentioned in the section above.
>
> This means that the value will always reflect the correct cache state.
> However, you cannot identify which individual item was served from the cache, or from the live API server.
> Instead, it will take the value from the whole request instead, which has `FromLive`, `PartiallyFromCache` or `FromCache`.

```cs
var cacheState = itemIds.HttpResponseInfo.CacheState;
```
