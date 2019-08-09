# Gw2Sharp
[![GitLab Pipeline](https://img.shields.io/gitlab/pipeline/archomeda/Gw2Sharp/master.svg?label=Pipeline&logo=gitlab)](https://gitlab.com/Archomeda/Gw2Sharp/pipelines)
[![AppVeyor Tests](https://img.shields.io/appveyor/tests/Archomeda/Gw2Sharp/master.svg?label=Tests&logo=appveyor)](https://ci.appveyor.com/project/Archomeda/Gw2Sharp/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Gw2Sharp.svg?label=NuGet&logo=nuget)](https://www.nuget.org/packages/Gw2Sharp)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Gw2Sharp.svg?label=Downloads&logo=nuget)](https://www.nuget.org/packages/Gw2Sharp)
[![Discord](https://img.shields.io/discord/384735285197537290.svg?label=Discord&logo=discord)](https://discord.gg/u2YDPea)  
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=coverage)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)

Gw2Sharp is a .NET wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.
It uses the latest C# 8.0 features like Nullable Reference Types because they're awesome.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.
*Make sure to read the [introductory guide](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html) to get started.*

## Supported services
The following services supported by Gw2Sharp:
- Render service - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#render-service)
- WebAPI v2 - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#web-api-v2), [endpoints](https://archomeda.github.io/Gw2Sharp/master/guides/endpoints.html)

## Requirements
This project targets .NET Standard 2.0.
It supports the C# 8.0 Nullable Reference Types feature for your convenience (which is available since Visual Studio 2019), but it's not required when consuming the library.

## Installing
### Release builds
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/), or you can install it by running the following command in the package manager console:
```powershell
Install-Package Gw2Sharp
```

### CI builds
On every build, a new package is created on [AppVeyor](https://ci.appveyor.com/project/Archomeda/Gw2Sharp/branch/master) that you can consume as well. Note that these builds are not considered to be stable, they are meant only for testing purposes. Therefore, these packages are also compiled in debug configuration and have their symbols included.

First, you'll have to create a new `nuget.config` file and add the AppVeyor package source to it:
```xml
<add key="Gw2Sharp-AppVeyor" value="https://ci.appveyor.com/nuget/gw2sharp-c900m3msesag" />
```

Afterwards, you can install a specific version by selecting one in the package manager GUI, or by running the following command in the package manager console:
```powershell
Install-Package Gw2Sharp -Version x.x.x-appveyor.yyyy
```

## Usage
For basic usage, check out the [introductory guide](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html).  
You can find the other guides there as well to help you get started on the advanced usage of Gw2Sharp, such as caching and exception handling.

## Compiling
Visual Studio 2019 (16.2) or later is required.
Because Gw2Sharp uses many new C# 8.0 features, make sure to install [.NET Core SDK 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0) as well.

## Contributing
Contributing is always welcome, but please keep them in scope of this project.
I'm looking for all contributions that fixes bugs.
But regarding implementing new features, it's better to raise an issue first explaining why that new feature should be added.

If you're adding something new, do add some tests for it as well.
I'm aiming for this project to be as stable as possible.
