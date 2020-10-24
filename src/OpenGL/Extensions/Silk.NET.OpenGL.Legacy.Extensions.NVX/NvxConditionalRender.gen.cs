// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.OpenGL.Legacy;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.NVX
{
    [Extension("NVX_conditional_render")]
    public unsafe partial class NvxConditionalRender : NativeExtension<GL>
    {
        public const string ExtensionName = "NVX_conditional_render";
        [NativeApi(EntryPoint = "glBeginConditionalRenderNVX")]
        public partial void BeginConditionalRender([Flow(FlowDirection.In)] uint id);

        [NativeApi(EntryPoint = "glEndConditionalRenderNVX")]
        public partial void EndConditionalRender();

        public NvxConditionalRender(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

