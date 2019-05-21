---
uid: Guides.Introduction
title: Gw2Sharp Introduction
---

# Introduction
The library is written to be as close as possible with the API endpoints.
This means that the basic functionality is easy to understand.

You start with creating a `Connection`:
```cs
// The constructor also accepts overloads with an access token and locale
var connection = new Gw2Sharp.WebApi.Connection();
```

Then you'll need to create the `Gw2WebApiClient`:
```cs
var client = new Gw2Sharp.WebApi.Gw2WebApiClient(connection);
```

Now you're ready!  
Keep in mind that all API calls are done asynchronously.
Depending on the API endpoint, you'll find that the following methods are available:
- `Ids()` - Gets the full list of ids
- `Get()` - Gets a single item or an API blob object
- `Many()` - Gets multiple items at once (bulk)
- `Page()` - Gets a page
- `All()` - Gets all items at once (bulk all)

Check the [features](../features.md) for the full list of supported endpoint operations.

If an endpoint has sub-endpoints, you can access them as a property.

For example, you can do the following:

```cs
// Get all item ids
var ids = await client.V2.Items.Ids();

// Get a single achievement
var item = await client.V2.Achievements.Get(123);

// Get multiple gliders
var items = await client.V2.Gliders.Many(new[] { 123, 456 });

// Get itemstats by page
var page = await client.V2.Itemstats.Page(5);

// Get all colors
var all = await client.V2.Colors.All();

// Access account sub-endpoints (e.g. account/home/cats that contains blob data)
var accountCats = await client.V2.Account.Home.Cats.Get();
```
