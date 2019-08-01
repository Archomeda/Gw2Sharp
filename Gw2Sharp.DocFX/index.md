# Gw2Sharp Documentation
Gw2Sharp is a .NET wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.
It uses the latest C# 8.0 features like Nullable Reference Types because they're awesome.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.
*Make sure to read the [introductory guide](xref:Guides.Introduction) to get started.*

## Supported services
The following services supported by Gw2Sharp:
- Render service - [introduction](xref:Guides.Introduction#render-service)
- WebAPI v2 - [introduction](xref:Guides.Introduction#web-api-v2), [endpoints](xref:Guides.Endpoints)

## Requirements
This project targets .NET Standard 2.0.
It supports the C# 8.0 Nullable Reference Types feature for your convenience (which is available since Visual Studio 2019), but it's not required when consuming the library.

## Installing
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/), or you can install it by running the following command in the package manager:

```powershell
Install-Package Gw2Sharp
```

## Additional resources
- [GW2 Development Community Discord](https://discord.gg/hNcpDT3) - Discussions about Gw2Sharp and other API related projects
- [Guild Wars 2 Wiki](https://wiki.guildwars2.com/wiki/API) - Community Wiki articles about the API
- [GitHub repository](https://github.com/Archomeda/Gw2Sharp)
- [NuGet feed](https://www.nuget.org/packages/Gw2Sharp/)
- [GitLab Pipeline](https://gitlab.com/Archomeda/Gw2Sharp/pipelines) - Nightly builds via Continuous Integration
- [AppVeyor CI](https://ci.appveyor.com/project/Archomeda/Gw2Sharp) - Automatic tests via Continuous Integration
