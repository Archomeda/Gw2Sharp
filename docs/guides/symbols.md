---
uid: Guides.Symbols
title: Debug symbols
---

# Debug symbols
Debug symbols for Gw2Sharp are uploaded separately to the NuGet symbol server.
In order to enable symbols while debugging, you need to add the symbol server to the Visual Studio settings (only supported in version 2017 15.9 or later):

1. Go to **Tools** > **Options** > **Debugging** > **Symbols** (or **Debug** > **Options** > **Symbols**)
2. Under **Symbol file (.pdb) locations**, add a new symbol server location by selecting the **+** symbol in the toolbar; use the following URL `https://symbols.nuget.org/download/symbols`

For more information, please visit [Microsoft's blog post](https://devblogs.microsoft.com/nuget/improved-package-debugging-experience-with-the-nuget-org-symbol-server/).
