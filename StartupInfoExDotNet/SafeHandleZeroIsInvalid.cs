using System.Runtime.InteropServices;

namespace StartupInfoExDotNet;

internal sealed class SafeHandleZeroIsInvalid : SafeHandle
{
    public SafeHandleZeroIsInvalid(IntPtr existingHandle) : base(IntPtr.Zero, true)
    {
        SetHandle(existingHandle);
    }

    protected override bool ReleaseHandle()
    {
        return CloseHandle(handle);
    }

    public override bool IsInvalid => handle == IntPtr.Zero;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr handle);
}