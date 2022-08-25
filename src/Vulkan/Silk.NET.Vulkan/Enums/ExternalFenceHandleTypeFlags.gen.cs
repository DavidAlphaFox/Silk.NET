// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [Flags]
    [NativeName("Name", "VkExternalFenceHandleTypeFlags")]
    public enum ExternalFenceHandleTypeFlags : int
    {
        [NativeName("Name", "")]
        None = 0,
        [Obsolete("Deprecated in favour of \"OpaqueFDBit\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT")]
        ExternalFenceHandleTypeOpaqueFDBit = 1,
        [Obsolete("Deprecated in favour of \"OpaqueWin32Bit\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT")]
        ExternalFenceHandleTypeOpaqueWin32Bit = 2,
        [Obsolete("Deprecated in favour of \"OpaqueWin32KmtBit\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT")]
        ExternalFenceHandleTypeOpaqueWin32KmtBit = 4,
        [Obsolete("Deprecated in favour of \"SyncFDBit\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT")]
        ExternalFenceHandleTypeSyncFDBit = 8,
        [Obsolete("Deprecated in favour of \"Reserved4BitNV\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_RESERVED_4_BIT_NV")]
        ExternalFenceHandleTypeReserved4BitNV = 16,
        [Obsolete("Deprecated in favour of \"Reserved5BitNV\"")]
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_RESERVED_5_BIT_NV")]
        ExternalFenceHandleTypeReserved5BitNV = 32,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT")]
        OpaqueFDBit = 1,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT")]
        OpaqueWin32Bit = 2,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT")]
        OpaqueWin32KmtBit = 4,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT")]
        SyncFDBit = 8,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_RESERVED_4_BIT_NV")]
        Reserved4BitNV = 16,
        [NativeName("Name", "VK_EXTERNAL_FENCE_HANDLE_TYPE_RESERVED_5_BIT_NV")]
        Reserved5BitNV = 32,
    }
}
