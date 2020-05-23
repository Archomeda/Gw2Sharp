// This file is from https://github.com/dotnet/runtime/blob/6ef044171a8e9479553c0fb0c9e96a9e8581bb3a/src/libraries/Microsoft.Bcl.HashCode/src/Interop.GetRandomBytes.cs
// The alternative is to use https://www.nuget.org/packages/Microsoft.Bcl.HashCode but I don't want to include another dependency 
#pragma warning disable

#if NETSTANDARD
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

internal partial class Interop
{
    internal static unsafe void GetRandomBytes(byte* buffer, int length)
    {
        byte[] bytes = Guid.NewGuid().ToByteArray();
        buffer = (byte*)BitConverter.ToUInt32(bytes, 0);
    }
}
#endif
