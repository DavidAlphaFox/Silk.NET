// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct2D
{
    [NativeName("Name", "D2D1_BRIGHTNESS_PROP")]
    public enum BrightnessProp : int
    {
        [Obsolete("Deprecated in favour of \"WhitePoint\"")]
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_WHITE_POINT")]
        BrightnessPropWhitePoint = 0x0,
        [Obsolete("Deprecated in favour of \"BlackPoint\"")]
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_BLACK_POINT")]
        BrightnessPropBlackPoint = 0x1,
        [Obsolete("Deprecated in favour of \"ForceDword\"")]
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_FORCE_DWORD")]
        BrightnessPropForceDword = unchecked((int) 0xFFFFFFFFFFFFFFFF),
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_WHITE_POINT")]
        WhitePoint = 0x0,
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_BLACK_POINT")]
        BlackPoint = 0x1,
        [NativeName("Name", "D2D1_BRIGHTNESS_PROP_FORCE_DWORD")]
        ForceDword = unchecked((int) 0xFFFFFFFFFFFFFFFF),
    }
}
