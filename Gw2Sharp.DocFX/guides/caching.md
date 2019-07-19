---
uid: Guides.Caching
title: Gw2Sharp Caching
---

# Caching
By default, Gw2Sharp will cache all API requests in memory.
Requests to the render services are not cached by default, however.

You can override this behavior by passing a custom cache method to the `Connection` constructor.
The following cache methods are available in the `Gw2Sharp.WebApi.Caching` namespace:
- `NullCacheMethod`: does not cache at all (default for render)
- `MemoryCacheMethod`: caches in-memory (default for API)
- `ArchiveCacheMethod`: caches in a ZIP archive for persistent storage (recommended for render)

If none of these provided cache methods suit your needs, you can bring your own cache method by implementing `ICacheMethod` in your own class, or by inheriting from the abstract `BaseCacheMethod` class.

The following example shows how you can pass a custom cache method to a `Connection`:
```cs
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;

// The default constructor will use in-memory caching for API requests,
// and no caching for render requests
var connectionWithDefaultCache = new Connection();

var connectionWithCustomCache = new Connection
{
     // No cache for API requests
    CacheMethod = new NullCacheMethod(),

    // Persistent ZIP storage for render requests
    RenderCacheMethod = new ArchiveCacheMethod("render-cache.zip")
};
```

**Heads up!**  
It's possible to share one instance of `MemoryCacheMethod` or `ArchiveCacheMethod` across different instances of `Connection`s.  
In case of `ArchiveCacheMethod`, do **not** create *multiple* instances of this class with references to the same file.
A ZIP archive file can only be used by *one* instance of `ArchiveCacheMethod`.
