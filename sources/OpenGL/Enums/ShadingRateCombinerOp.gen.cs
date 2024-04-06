// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum ShadingRateCombinerOp
{
    KeepEXT = 0x96D2,
    ReplaceEXT = 0x96D3,
    MinExt = 0x96D4,
    MaxExt = 0x96D5,
    MulExt = 0x96D6
}
