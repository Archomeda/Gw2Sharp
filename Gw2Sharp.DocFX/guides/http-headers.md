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
var itemIds = await client.V2.Items.PageAsync(0);

var cacheExpires = itemIds.HttpResponseInfo.Expires;
var cacheAge = itemIds.HttpResponseInfo.CacheMaxAge;
var itemsCount = itemIds.HttpResponseInfo.ResultCount;
var itemsTotal = itemIds.HttpResponseInfo.ResultTotal;
var pagesTotal = itemIds.HttpResponseInfo.PageTotal;
```
