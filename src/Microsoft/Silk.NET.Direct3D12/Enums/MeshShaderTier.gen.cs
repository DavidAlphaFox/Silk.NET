// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_MESH_SHADER_TIER")]
    public enum MeshShaderTier : int
    {
        [Obsolete("Deprecated in favour of \"TierNotSupported\"")]
        [NativeName("Name", "D3D12_MESH_SHADER_TIER_NOT_SUPPORTED")]
        MeshShaderTierNotSupported = 0x0,
        [Obsolete("Deprecated in favour of \"Tier1\"")]
        [NativeName("Name", "D3D12_MESH_SHADER_TIER_1")]
        MeshShaderTier1 = 0xA,
        [NativeName("Name", "D3D12_MESH_SHADER_TIER_NOT_SUPPORTED")]
        TierNotSupported = 0x0,
        [NativeName("Name", "D3D12_MESH_SHADER_TIER_1")]
        Tier1 = 0xA,
    }
}
