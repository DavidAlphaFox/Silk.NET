// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Ported from the OpenGL Core Profile headers and corresponding dependencies.
// Original source is Copyright 2013-2020 The Khronos Group Inc. Licensed under the MIT license.
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Transformed]
public enum DebugSeverity
{
    DontCare = 0x1100,
    DebugSeverityHigh = 0x9146,
    DebugSeverityMedium = 0x9147,
    DebugSeverityLow = 0x9148,
    DebugSeverityNotification = 0x826B
}