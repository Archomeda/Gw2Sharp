---
uid: Guides.LastModified
title: Checking the Last-Modified header
---

# Checking the `Last-Modified` header
This header is used to check the last time the content you're accessing has been changed.
It was added to the API on March 22nd, 2019.
You can read up on it [on the forums](https://en-forum.guildwars2.com/discussion/72091/api-updates-march-22-2019).

Gw2Sharp allows you to check this header through the same way as [the other headers](http-headers.md).

An example:

```cs
// Assuming you already have a client
var character = await client.V2.Characters["Your Character Name"].GetAsync();
var lastModified = character.HttpResponseInfo.LastModified;

// Note that both HttpResponseInfo and LastModified are nullable
// - HttpResponseInfo is null if the response object doesn't contain response information (e.g. when this object is not the root object of the response)
// - LastModified is null if the response doesn't contain the header
```
