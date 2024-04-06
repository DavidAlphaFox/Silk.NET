// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum SamplerParameterI
{
    MagFilter = 0x2800,
    MinFilter = 0x2801,
    WrapS = 0x2802,
    WrapT = 0x2803,
    WrapR = 0x8072,
    CompareMode = 0x884C,
    CompareFunc = 0x884D,
    UnnormalizedCoordinatesARM = 0x8F6A
}
