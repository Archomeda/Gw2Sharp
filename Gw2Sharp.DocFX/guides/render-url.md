---
uid: Guides.RenderUrl
title: Using RenderUrl
---

# Using RenderUrl
The `RenderUrl` is a custom struct that makes it easier to download assets from the Guild Wars 2 render service.
All web API properties that are URLs, are automatically converted to `RenderUrl`s.
The difference is best explained with an example:

```cs
// Assuming you already have a client

// Normal
var item = await client.WebApi.V2.Items.GetAsync(64240);
var icon = await client.Render.DownloadToByteArrayAsync(item.Icon);

// RenderUrl
var item = await client.WebApi.V2.Items.GetAsync(64240);
var icon = await item.Icon.DownloadToByteArrayAsync();
```

It doesn't save you many characters, but it does make it more intuitive, because you don't have to explicitly use the Render client yourself.
Instead, you can pass along the model you got from the API, and still download the icon somewhere else without even knowing that the Render client exists.
