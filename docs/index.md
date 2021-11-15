# Gw2Sharp Documentation
Gw2Sharp is a cross-platform .NET wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.
*Make sure to read the [introductory guide](xref:Guides.Introduction) to get started.*

## Supported services
The following services are supported by Gw2Sharp:
- WebAPI v2 - [introduction](xref:Guides.Introduction#web-api-v2), [endpoints](xref:Guides.Endpoints)
- Render service - [introduction](xref:Guides.Introduction#render-service)
- Mumble service - [introduction](xref:Guides.Introduction#mumble-link)
- Chat links - [introduction](xref:Guides.Introduction#chat-links)

## Requirements
This project targets .NET 5, .NET Core 3.1 and .NET Standard 2.0 for compatibility with older .NET Frameworks (check the [.NET Standard 2.0 compatibility table](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support))
It supports the C# 8.0 nullable reference types feature for your convenience, but it's not required when consuming the library.

## Installing
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/). Or, alternatively, you can install it by running `dotnet add package Gw2Sharp` in a console, or `Install-Package Gw2Sharp` in the package manager console.

## Additional resources
- [GW2 Development Community Discord](https://discord.gg/hNcpDT3) - Discussions about Gw2Sharp and other API related projects
- [Guild Wars 2 Wiki](https://wiki.guildwars2.com/wiki/API) - Community Wiki articles about the API
- [GitHub repository](https://github.com/Archomeda/Gw2Sharp)
- [NuGet feed](https://www.nuget.org/packages/Gw2Sharp/)
