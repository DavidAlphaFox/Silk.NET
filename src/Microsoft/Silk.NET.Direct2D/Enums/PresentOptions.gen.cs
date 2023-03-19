// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct2D
{
    [NativeName("Name", "D2D1_PRESENT_OPTIONS")]
    public enum PresentOptions : int
    {
        [Obsolete("Deprecated in favour of \"None\"")]
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_NONE")]
        PresentOptionsNone = 0x0,
        [Obsolete("Deprecated in favour of \"RetainContents\"")]
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS")]
        PresentOptionsRetainContents = 0x1,
        [Obsolete("Deprecated in favour of \"Immediately\"")]
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_IMMEDIATELY")]
        PresentOptionsImmediately = 0x2,
        [Obsolete("Deprecated in favour of \"ForceDword\"")]
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_FORCE_DWORD")]
        PresentOptionsForceDword = unchecked((int) 0xFFFFFFFFFFFFFFFF),
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_NONE")]
        None = 0x0,
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS")]
        RetainContents = 0x1,
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_IMMEDIATELY")]
        Immediately = 0x2,
        [NativeName("Name", "D2D1_PRESENT_OPTIONS_FORCE_DWORD")]
        ForceDword = unchecked((int) 0xFFFFFFFFFFFFFFFF),
    }
}
