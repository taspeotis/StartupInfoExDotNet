using System.Runtime.InteropServices;

namespace StartupInfoExDotNet;

[StructLayout(LayoutKind.Sequential)]
internal sealed class ProcessInformation
{
    public IntPtr hProcess = IntPtr.Zero;
    public IntPtr hThread = IntPtr.Zero;
    public uint dwProcessId = 0;
    public uint dwThreadId = 0;
}