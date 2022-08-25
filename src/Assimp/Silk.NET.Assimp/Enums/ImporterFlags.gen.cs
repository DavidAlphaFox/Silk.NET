// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Assimp
{
    [Flags]
    [NativeName("Name", "aiImporterFlags")]
    public enum ImporterFlags : int
    {
        [NativeName("Name", "")]
        None = 0,
        [Obsolete("Deprecated in favour of \"SupportTextFlavour\"")]
        [NativeName("Name", "aiImporterFlags_SupportTextFlavour")]
        ImporterFlagsSupportTextFlavour = 0x1,
        [Obsolete("Deprecated in favour of \"SupportBinaryFlavour\"")]
        [NativeName("Name", "aiImporterFlags_SupportBinaryFlavour")]
        ImporterFlagsSupportBinaryFlavour = 0x2,
        [Obsolete("Deprecated in favour of \"SupportCompressedFlavour\"")]
        [NativeName("Name", "aiImporterFlags_SupportCompressedFlavour")]
        ImporterFlagsSupportCompressedFlavour = 0x4,
        [Obsolete("Deprecated in favour of \"LimitedSupport\"")]
        [NativeName("Name", "aiImporterFlags_LimitedSupport")]
        ImporterFlagsLimitedSupport = 0x8,
        [Obsolete("Deprecated in favour of \"Experimental\"")]
        [NativeName("Name", "aiImporterFlags_Experimental")]
        ImporterFlagsExperimental = 0x10,
        [NativeName("Name", "aiImporterFlags_SupportTextFlavour")]
        SupportTextFlavour = 0x1,
        [NativeName("Name", "aiImporterFlags_SupportBinaryFlavour")]
        SupportBinaryFlavour = 0x2,
        [NativeName("Name", "aiImporterFlags_SupportCompressedFlavour")]
        SupportCompressedFlavour = 0x4,
        [NativeName("Name", "aiImporterFlags_LimitedSupport")]
        LimitedSupport = 0x8,
        [NativeName("Name", "aiImporterFlags_Experimental")]
        Experimental = 0x10,
    }
}
