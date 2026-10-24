using System.IO;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization.Json.Extensions;

unsafe sealed class StringStream : UnmanagedMemoryStream
{
    readonly GCHandle _handle;

    internal StringStream(string value)
    {
        _handle = GCHandle.Alloc(value, GCHandleType.Pinned);

        var length = sizeof(char) * value.Length;
        var pointer = (byte*)_handle.AddrOfPinnedObject();

        Initialize(pointer, length, length, FileAccess.Read);
    }

    protected override void Dispose(bool disposing)
    {
        if (_handle.IsAllocated)
            _handle.Free();
        base.Dispose(disposing);
    }

    ~StringStream() => Dispose(false);
}