// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.SDL
{
    [Flags]
    [NativeName("AnonymousName", "__AnonymousEnum_SDL_shape_L85_C9")]
    [NativeName("Name", "WindowShapeMode")]
    public enum WindowShapeMode : int
    {
        [NativeName("Name", "")]
        None = 0,
        [NativeName("Name", "ShapeModeDefault")]
        ShapeModeDefault = 0x0,
        [NativeName("Name", "ShapeModeBinarizeAlpha")]
        ShapeModeBinarizeAlpha = 0x1,
        [NativeName("Name", "ShapeModeReverseBinarizeAlpha")]
        ShapeModeReverseBinarizeAlpha = 0x2,
        [NativeName("Name", "ShapeModeColorKey")]
        ShapeModeColorKey = 0x3,
    }
}