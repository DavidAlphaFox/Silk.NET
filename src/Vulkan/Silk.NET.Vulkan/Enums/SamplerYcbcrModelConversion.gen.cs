// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;

namespace Silk.NET.Vulkan
{
    public enum SamplerYcbcrModelConversion
    {
        RgbIdentity = 0,
        YcbcrIdentity = 1,
        Ycbcr709 = 2,
        Ycbcr601 = 3,
        Ycbcr2020 = 4,
    }
}