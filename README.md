# Gw2Sharp
Gw2Sharp is a .NET standard wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.
It uses the latest C# 8.0 features like Nullable Reference Types because they're awesome.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.

## Requirements
This project requires .NET Standard 2.0 and supports the C# 8.0 Nullable Reference Types feature for your convenience (optional when referencing this library).

## Installing
TODO: NuGet

## Usage
### Basic usage
```cs
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.V2;

// Make a connection with optionally: an access token, language.
var connection = new Connection("optional-access-token", Locale.English);

// Make a client and pass the connection to it
var client = new Gw2WebApiClient(connection);

// Get all item ids
var ids = await client.V2.Items.Ids();

// Get a single item
var item = await client.V2.Items.Get(123);

// Get multiple items
var items = await client.V2.Items.Many(new[] { 123, 456 });

// Get items by page
var page = await client.V2.Items.Page(5);

// Getting all items is not supported by the API.
// Any other endpoint that does support it, it will work as follows:
var all = await client.V2.Colors.All();
```

### Caching
By default, API requests are cached in memory.
You can override this by passing it to the `Connection` constructor.
There are two cache methods provided in `Gw2Sharp.WebApi.Caching`: `NullCacheMethod` and `MemoryCacheMethod`.
You can create your own cache method by implementing the `ICacheMethod` interface or by inheriting from the abstract `BaseCacheMethod` class.

## Compiling
Visual Studio 2019 Preview 3 or later is required.
There are no specific build instructions.

## Contributing
I'm open for any contributions you can make. If you find a bug, create an issue
here on GitHub. GitHub is very nice with maintaining a list of issues.
Submitting a bug report on the Steam Workshop is also appreciated, but it might
take a little longer for me to respond, because I prefer GitHub. If you know C#,
you can try to fix it yourself and submit a pull request.
