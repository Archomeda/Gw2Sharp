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
This project targets .NET Core 3.1 and .NET Standard 2.0 for compatibility with older .NET Frameworks.
It supports the C# 8.0 nullable reference types feature for your convenience, but it's not required when consuming the library.

## Installing
### Release builds
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/), or you can install it by running the following command in the package manager console:
```powershell
Install-Package Gw2Sharp
```

### CI builds
Whenever a new commit is pushed, a workflow will run on GitHub Actions.
This will result in a new CI build that will be automatically uploaded to a [separate NuGet feed on Azure Artifacts](https://dev.azure.com/archomeda/Gw2Sharp/_packaging?_a=feed&feed=Nightly).
Note that these builds are not considered to be stable, they are meant only for testing purposes.
Therefore, these packages are also compiled in debug configuration and have their symbols included.

First, you'll have to create a new `nuget.config` file and add the package source to it:
```xml
<add key="Gw2Sharp-Nightly" value="https://pkgs.dev.azure.com/Archomeda/Gw2Sharp/_packaging/Nightly/nuget/v3/index.json" />
```

Afterwards, you can install a specific version by choosing one in your package manager.
**Keep in mind that versions uploaded to this feed will not be available forever.**

## Additional resources
- [GW2 Development Community Discord](https://discord.gg/hNcpDT3) - Discussions about Gw2Sharp and other API related projects
- [Guild Wars 2 Wiki](https://wiki.guildwars2.com/wiki/API) - Community Wiki articles about the API
- [GitHub repository](https://github.com/Archomeda/Gw2Sharp)
- [NuGet feed](https://www.nuget.org/packages/Gw2Sharp/)
- [Azure Artifacts NuGet feed](https://dev.azure.com/archomeda/Gw2Sharp/_packaging?_a=feed&feed=Nightly) - CI builds
