---
uid: Guides.Proxy
title: Proxying the API
---

# Proxying the API
Starting with version 1.6.0, you can use a different base URL for the API calls.
This means that instead of using `https://api.guildwars2.com/` as server, you can use any other base URL.
The path to the endpoints stay the same, so your proxy server needs to match the official API server.

Gw2Sharp also supports replacing the base URL for render API calls.
The concept is the same, but because these URLs are returned from the API server and not constructed by Gw2Sharp, Gw2Sharp replaces all hostnames to `https://render.guildwars2.com/` with your base URL (this is visible in the [RenderUrl objects](xref:Guides.RenderUrl)).

You can set these options in your `Connection` object:

```cs
var connection = new Gw2Sharp.Connection();

// The following sets the API base URL, this defaults to https://api.guildwars2.com/.
connection.ApiBaseUrl = "https://my.proxy.server.example.com/";

// The following sets the render API base URL,
// this defaults to null which means that no replacement will be done
connection.RenderBaseUrl = "https://my.render.server.example.com/";
```

> [!WARNING]
> Setting the `RenderBaseUrl` to anything else than `null`, will replace the render API hostname with that value. This includes an empty string!

## Using a different API server region
The Guild Wars 2 API server is hosted in both NA and EU region, but using `https://api.guildwars2.com/` will load balance you to the closest region you're sending the request from.
You can override this by proxying to the other region's IP address explicitly.
How to get those IP addresses is out-of-scope for this guide, but there's one thing you need to do extra in Gw2Sharp in order to support this.

Basically, whenever an HTTP request is done, any sane client will automatically set the `Host` header to the domain you're requesting a page from.
This also means that, when you set an IP address, this IP address is used for the `Host` header, and not `api.guildwars2.com`.
So you'll have to override this behavior by writing a custom Gw2Sharp middleware that will set this header in the [`Gw2Sharp.WebApi.Middleware.IWebApiMiddleware.OnRequestAsync`](../api/Gw2Sharp.WebApi.Middleware.IWebApiMiddleware.html) method.
The middleware context contains the `Request.Options.RequestHeaders` property where you can add a `Host` header.
