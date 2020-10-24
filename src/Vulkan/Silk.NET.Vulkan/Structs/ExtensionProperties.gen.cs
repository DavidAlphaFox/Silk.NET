// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkExtensionProperties")]
    public unsafe partial struct ExtensionProperties
    {
        public ExtensionProperties
        (
            uint? specVersion = null
        ) : this()
        {
            if (specVersion is not null)
            {
                SpecVersion = specVersion.Value;
            }
        }

        /// <summary></summary>
        [NativeName("Type", "char")]
        [NativeName("Type.Name", "char")]
        [NativeName("Name", "extensionName")]
        public fixed byte ExtensionName[256];
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "specVersion")]
        public uint SpecVersion;
    }
}
