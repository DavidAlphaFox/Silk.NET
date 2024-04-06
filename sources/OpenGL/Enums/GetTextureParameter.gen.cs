// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum GetTextureParameter
{
    TextureWidth = 0x1000,
    TextureHeight = 0x1001,
    TextureBorderColor = 0x1004,
    TextureMagFilter = 0x2800,
    TextureMinFilter = 0x2801,
    TextureWrapS = 0x2802,
    TextureWrapT = 0x2803,
    TextureInternalFormat = 0x1003,
    TextureRedSize = 0x805C,
    TextureGreenSize = 0x805D,
    TextureBlueSize = 0x805E,
    TextureAlphaSize = 0x805F,
    TextureComponents = 0x1003,
    TextureBorder = 0x1005,
    TextureLuminanceSize = 0x8060,
    TextureIntensitySize = 0x8061,
    TexturePriority = 0x8066,
    TextureResident = 0x8067,
    NormalMap = 0x8511,
    ReflectionMap = 0x8512,
    NormalMapARB = 0x8511,
    ReflectionMapARB = 0x8512,
    TextureDepthEXT = 0x8071,
    TextureWrapREXT = 0x8072,
    NormalMapEXT = 0x8511,
    ReflectionMapEXT = 0x8512,
    NormalMapNV = 0x8511,
    ReflectionMapNV = 0x8512,
    DetailTextureLevelSGIS = 0x809A,
    DetailTextureModeSGIS = 0x809B,
    DetailTextureFuncPointsSGIS = 0x809C,
    GenerateMipmapSGIS = 0x8191,
    SharpenTextureFuncPointsSGIS = 0x80B0,
    Texture4DsizeSGIS = 0x8136,
    TextureWrapQSGIS = 0x8137,
    TextureFilter4SizeSGIS = 0x8147,
    TextureMinLodSGIS = 0x813A,
    TextureMaxLodSGIS = 0x813B,
    TextureBaseLevelSGIS = 0x813C,
    TextureMaxLevelSGIS = 0x813D,
    DualTextureSelectSGIS = 0x8124,
    QuadTextureSelectSGIS = 0x8125,
    TextureClipmapCenterSGIX = 0x8171,
    TextureClipmapFrameSGIX = 0x8172,
    TextureClipmapOffsetSGIX = 0x8173,
    TextureClipmapVirtualDepthSGIX = 0x8174,
    TextureClipmapLodOffsetSGIX = 0x8175,
    TextureClipmapDepthSGIX = 0x8176,
    TextureCompareSGIX = 0x819A,
    TextureCompareOperatorSGIX = 0x819B,
    TextureLequalRSGIX = 0x819C,
    TextureGequalRSGIX = 0x819D,
    ShadowAmbientSGIX = 0x80BF,
    TextureMaxClampSSGIX = 0x8369,
    TextureMaxClampTSGIX = 0x836A,
    TextureMaxClampRSGIX = 0x836B,
    TextureLodBiasSSGIX = 0x818E,
    TextureLodBiasTSGIX = 0x818F,
    TextureLodBiasRSGIX = 0x8190,
    PostTextureFilterBiasSGIX = 0x8179,
    PostTextureFilterScaleSGIX = 0x817A,
    NormalMapOES = 0x8511,
    ReflectionMapOES = 0x8512,
    TextureUnnormalizedCoordinatesARM = 0x8F6A,
    SurfaceCompressionEXT = 0x96C0,
    TextureBorderColorNV = 0x1004
}
