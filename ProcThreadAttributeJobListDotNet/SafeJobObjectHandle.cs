using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace ProcThreadAttributeJobListDotNet;

[PublicAPI]
public sealed class SafeJobObjectHandle : SafeHandle
{
    public SafeJobObjectHandle(IntPtr existingHandle) : base(IntPtr.Zero, true)
    {
        SetHandle(existingHandle);
    }

    public override bool IsInvalid => handle == IntPtr.Zero;

    protected override bool ReleaseHandle()
    {
        return CloseHandle(handle);
    }

    [DllImport(Constants.Kernel32DllName, SetLastError = true)]
    private static extern bool CloseHandle(IntPtr handle);
}