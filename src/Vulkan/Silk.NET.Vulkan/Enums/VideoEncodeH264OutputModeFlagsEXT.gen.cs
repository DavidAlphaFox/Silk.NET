// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [Flags]
    [NativeName("Name", "VkVideoEncodeH264OutputModeFlagsEXT")]
    public enum VideoEncodeH264OutputModeFlagsEXT : int
    {
        [NativeName("Name", "")]
        None = 0,
        [Obsolete("Deprecated in favour of \"FrameBitExt\"")]
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_FRAME_BIT_EXT")]
        VideoEncodeH264OutputModeFrameBitExt = 1,
        [Obsolete("Deprecated in favour of \"SliceBitExt\"")]
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_SLICE_BIT_EXT")]
        VideoEncodeH264OutputModeSliceBitExt = 2,
        [Obsolete("Deprecated in favour of \"NonVclBitExt\"")]
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_NON_VCL_BIT_EXT")]
        VideoEncodeH264OutputModeNonVclBitExt = 4,
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_FRAME_BIT_EXT")]
        FrameBitExt = 1,
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_SLICE_BIT_EXT")]
        SliceBitExt = 2,
        [NativeName("Name", "VK_VIDEO_ENCODE_H264_OUTPUT_MODE_NON_VCL_BIT_EXT")]
        NonVclBitExt = 4,
    }
}
