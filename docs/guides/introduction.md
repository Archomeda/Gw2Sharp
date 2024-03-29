---
uid: Guides.Introduction
title: Gw2Sharp Introduction
---

# Introduction
The library is written to be as close as possible with the API endpoints.
This means that the basic functionality is easy to understand.

Start with creating a `Connection`:
```cs
// The constructor also accepts overloads with an access token and locale
var connection = new Gw2Sharp.Connection();
```

Then, create the `Gw2Client`:
```cs
using var client = new Gw2Sharp.Gw2Client(connection);
// Note that Gw2Client implements IDisposable!
// Make sure to dispose it explicitly by calling .Dispose(),
// or use the using statement to dispose automatically
```

Now you're ready!

To get started with a specific service, go to one of the following services supported by Gw2Sharp:
- [WebAPI v2](#web-api-v2)
- [Render service](#render-service)
- [Mumble Link](#mumble-link)
- [Chat links](#chat-links)

---

## Web API v2
Accessing the web API v2 service is done through the main `Gw2Sharp.Gw2Client`:
```cs
var webApiClient = client.WebApi.V2;
```

This client exposes the web API endpoints that are available at https://api.guildwars2.com/v2 in a 1:1 relation.
This means that, for example if you want to access the unlocked mount skins on your account, you can access it in the same path as the web API:

```cs
var unlockedMountSkinsClient = webApiClient.Account.Mounts.Skins;
```

Next step is to actually get the information from the API.  
Depending on the endpoint, you'll find that the following methods are available:
- `IdsAsync()` - Gets the full list of ids
- `GetAsync()` - Gets a single item or an API blob object
- `ManyAsync()` - Gets multiple items at once (bulk)
- `PageAsync()` - Gets a page
- `AllAsync()` - Gets all items at once (bulk all)

For example, you can do the following:

```cs
// Get all item ids
var ids = await client.WebApi.V2.Items.IdsAsync();

// Get a single achievement
var item = await client.WebApi.V2.Achievements.GetAsync(123);

// Get multiple gliders
var items = await client.WebApi.V2.Gliders.ManyAsync(new[] { 123, 456 });

// Get itemstats by page (page numbers are 0-indexed)
var page = await client.WebApi.V2.Itemstats.PageAsync(5);

// Get all colors
var all = await client.WebApi.V2.Colors.AllAsync();

// Access account sub-endpoints (e.g. account/home/cats that contains blob data)
var accountCats = await client.WebApi.V2.Account.Home.Cats.GetAsync();

// Access sub-endpoints that require an id (e.g. characters/:id)
var characters = await client.WebApi.V2.Characters.AllAsync();
var tybaltLeftpaw = await client.WebApi.V2.Characters["Tybalt Leftpaw"].GetAsync();

// Accessing a nested sub-endpoint works as well
var tybaltsSpecializations = await client.WebApi.V2.Characters["Tybalt Leftpaw"].Specializations.GetAsync();
```

**Related topics:**
- [Caching](xref:Guides.Caching)
- [Checking the response info](xref:Guides.ResponseInfo)
- [Checking the Last-Modified header](xref:Guides.LastModified)
- [Creating and using subtokens](xref:Guides.Subtokens)
- [Exception handling](xref:Guides.ExceptionHandling)
- [Supported endpoints](xref:Guides.Endpoints)

---

## Render service
Accessing the render service is done through the main `Gw2Sharp.Gw2Client`:
```cs
var renderClient = client.WebApi.Render;
```

The render service client exposes a few methods that help with downloading image assets from the Guild Wars 2 render service.
For example:
```cs
var appleUrl = "https://render.guildwars2.com/file/17520D2F53CF62BFA696EDE02DA1F77445A9F796/63265.png";

// Downloads the apple icon into a byte array asynchronously
var apple = await renderClient.DownloadToByteArrayAsync(appleUrl);

// Downloads the apple icon into a stream asynchronously
using var appleStream = new MemoryStream();
await renderClient.DownloadToStreamAsync(appleStream, appleUrl);
```

**Related topics:**
- [Caching](xref:Guides.Caching)
- [Exception handling](xref:Guides.ExceptionHandling)
- [Using RenderUrl](xref:Guides.RenderUrl)

---

## Mumble Link
Accessing the Mumble Link service is done through the main `Gw2Sharp.Gw2Client`:
```cs
var mumbleClient = client.Mumble;
```

> [!WARNING]
> The Mumble Link service client requires Guild Wars 2 to be running on a Windows operating system.
>
> Starting with .NET 5, using this property without checking if you're targeting a Windows platform, [will raise a warning](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416).
> Accessing the property will throw a `PlatformNotSupportedException`.
> 
> In .NET Framework and .NET Core however, `PlatformNotSupportedException` is thrown as soon as you're calling `Update()` after accessing the property.
>
> The property `IsAvailable` will return `true` if the Guild Wars 2 client is running and the Mumble Link API is available.

> [!NOTE]
> You are responsible for updating the Mumble Link values by calling the method `Update()`.
> The update tick rate depends on how fast the game is updating the frames.
> For example, if Guild Wars 2 is running at 60 frames per second, the Mumble Link API will be updated 60 times per second.

Note that some of the values in `Gw2MumbleClient` are lazily evaluated.
The reason is that these values are parsed from a JSON string that Guild Wars 2 provides through the Mumble Link.
In order to keep performance to a maximum, the following JSON properties are only parsed when you request them:
- `CharacterName`
- `Profession`
- `Specialization`
- `Race`
- `TeamColorId`
- `IsCommander`
- `FieldOfView`
- `UiSize`

> [!TIP]
> If you need the performance, it's recommended to not request these values on every update, but to cache them locally, and only update once in a while.
> Any other value is safe to be read every tick without taking any additional performance hit.

### Custom Mumble Link names
Support for custom Mumble Link names has been added with the April 28th, 2020 update.
This means that you can use any custom name that's different from the default (which is `MumbleLink`).
In order to access any custom named Mumble Link, you can do the following:

```cs
var customMumbleClient = client.Mumble["AnyCustomNameHere"];

// You can treat the custom client the same as the normal client in terms of accessible data
```

All calls to the indexer are redirected to an internal cache of the used clients.
This is to make sure that only one instance of a given name is created to save resources, and that when the root client is disposed, all the child clients are disposed as well.
If just a child client is disposed however, the root client is untouched.

> [!TIP]
> Keep in mind that while the root client is disposable, you don't want to dispose it yourself manually.
> Disposing is done automatically whenever the `IGw2Client` is disposed.

---

## Chat links
Accessing the chat links is a bit different compared to the other services.
Methods regarding chat link parsing are static, while creating chat links is done through the respective item link type classes:

```cs
//
// Parsing chat links
//
var chatLink = "[&AgH1WQAA]";

// The following line may throw a FormatException if the chat link isn't valid 
var chatLinkObject = Gw2Sharp.ChatLinks.Gw2ChatLink.Parse(chatLink);
// OR use .TryParse(...) instead
if (Gw2Sharp.ChatLinks.Gw2ChatLink.TryParse(chatLink, out var chatLinkObject2))
{
    // Valid chat link
}
else
{
    // Invalid chat link
}

//
// Creating chat links
//
var chatLinkObject3 = new OutfitChatLink { OutfitId = 41 };
var chatLink3 = chatLinkObject3.ToString();
// chatLink3 == "[&CykAAAA=]"
```
