using Silk.NET.OpenGL;
using System;

namespace Tutorial
{
    //Our buffer object abstraction.
    public class BufferObject<TDataType> : IDisposable
        where TDataType : unmanaged
    {
        //Our handle, buffertype and the GL instance this class will use, these are private because they have no reason to be public.
        //Most of the time you would want to abstract items to make things like this invisible.
        private uint _handle;
        private BufferTargetARB _bufferType;
        private GL _gl;

        public unsafe BufferObject(GL gl, Span<TDataType> data, BufferTargetARB bufferType)
        {
            //Setting the gl instance and storing our buffer type.
            _gl = gl;
            _bufferType = bufferType;

            //Getting the handle, and then uploading the data to said handle.
            _handle = _gl.GenBuffer();
            Bind();
            fixed (void* d = data)
            {
<<<<<<< HEAD
                _gl.BufferData(bufferType, (UIntPtr) (data.Length * sizeof(TDataType)), d, BufferUsageARB.StaticDraw);
=======
                _gl.BufferData(bufferType, (uint) (data.Length * sizeof(TDataType)), d, BufferUsageARB.StaticDraw);
>>>>>>> master
            }
        }

        public void Bind()
        {
            //Binding the buffer object, with the correct buffer type.
            _gl.BindBuffer(_bufferType, _handle);
        }

        public void Dispose()
        {
            //Remember to delete our buffer.
            _gl.DeleteBuffer(_handle);
        }
    }
}
