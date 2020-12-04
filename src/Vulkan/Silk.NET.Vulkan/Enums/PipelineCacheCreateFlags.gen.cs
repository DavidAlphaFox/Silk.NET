// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [Flags()]
    [NativeName("Name", "VkPipelineCacheCreateFlags")]
    public enum PipelineCacheCreateFlags
    {
<<<<<<< HEAD
        [NativeName("Name", "VK_PIPELINE_CACHE_CREATE_RESERVED_1_BIT_EXT")]
        PipelineCacheCreateReserved1BitExt = 2,
        [NativeName("Name", "VK_PIPELINE_CACHE_CREATE_EXTERNALLY_SYNCHRONIZED_BIT_EXT")]
=======
        PipelineCacheCreateReserved1BitExt = 2,
>>>>>>> master
        PipelineCacheCreateExternallySynchronizedBitExt = 1,
    }
}
