// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum ExternalHandleType
{
    OpaqueFdEXT = 0x9586,
    OpaqueWin32EXT = 0x9587,
    OpaqueWin32KmtEXT = 0x9588,
    D3D12TilepoolEXT = 0x9589,
    D3D12ResourceEXT = 0x958A,
    D3D11ImageEXT = 0x958B,
    D3D11ImageKmtEXT = 0x958C,
    D3D12FenceEXT = 0x9594
}