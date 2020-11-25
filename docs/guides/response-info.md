---
uid: Guides.ResponseInfo
title: Checking the response info
---

# Checking the response info
Every response has the property `HttpResponseInfo`.
This property allows you to access the HTTP headers and other information that the response has returned.

An example:

```cs
// Assuming you already have a client
var itemIds = await client.WebApi.V2.Items.PageAsync(0);

var cacheExpires = itemIds.HttpResponseInfo.Expires;
var cacheAge = itemIds.HttpResponseInfo.CacheMaxAge;
var itemsCount = itemIds.HttpResponseInfo.ResultCount;
var itemsTotal = itemIds.HttpResponseInfo.ResultTotal;
var pagesTotal = itemIds.HttpResponseInfo.PageTotal;

// If the cache middleware is enabled, the following
// can be used to determine if the request was served
// from cache or from the live server
var cacheState = itemIds.HttpResponseInfo.CacheState;
```

> [!CAUTION]
> Due to technical limitations, performing a "many" request will only return the headers of the first item.
> These kind of requests will be performed as efficiently as possible, meaning that if the [cache middleware](xref:Guides.Middleware#cachemiddleware) is enabled, it will only request items from the live API server that are *not* available in the cache.
> Therefore, these headers might not reflect the actual response headers.

> [!NOTE]
> The cache state is unaffected by the technical limitations mentioned above, because it's manually injected by the [cache middleware](xref:Guides.Middleware#cachemiddleware).
> 
> It does, however, has its own limitation that you cannot identify which individual item was served from the cache, or from the live API server.
> Instead, it will take the value from the whole request instead, which is `FromLive`, `PartiallyFromCache` or `FromCache`.
>
> So if some items from a many request has been served from cache, and some from the live server, it will have the value `PartiallyFromCache`.
