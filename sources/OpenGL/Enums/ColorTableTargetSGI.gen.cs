// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum ColorTableTargetSGI
{
    ColorTable = 0x80D0,
    PostConvolutionColorTable = 0x80D1,
    PostColorMatrixColorTable = 0x80D2,
    ProxyColorTable = 0x80D3,
    ProxyPostConvolutionColorTable = 0x80D4,
    ProxyPostColorMatrixColorTable = 0x80D5,
    ColorTableSGI = 0x80D0,
    PostConvolutionColorTableSGI = 0x80D1,
    PostColorMatrixColorTableSGI = 0x80D2,
    ProxyColorTableSGI = 0x80D3,
    ProxyPostConvolutionColorTableSGI = 0x80D4,
    ProxyPostColorMatrixColorTableSGI = 0x80D5,
    TextureColorTableSGI = 0x80BC,
    ProxyTextureColorTableSGI = 0x80BD
}