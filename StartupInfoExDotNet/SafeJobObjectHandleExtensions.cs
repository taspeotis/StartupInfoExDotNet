using System.Diagnostics;
using System.Runtime.InteropServices;

namespace StartupInfoExDotNet;

public static class SafeJobObjectHandleExtensions
{
    public static Process CreateAssociatedProcess(SafeJobObjectHandle safeHandle, string fileName, string? arguments)
    {
        
    }

    [DllImport(Constants.Kernel32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool CreateProcess(
        string? lpApplicationName,
        string? lpCommandLine,
        IntPtr lpProcessAttributes,
        IntPtr lpThreadAttributes,
        bool bInheritHandles,
        uint dwCreationFlags,
        IntPtr lpEnvironment,
        string? lpCurrentDirectory,
        StartupInfoEx lpStartupInfo,
        out ProcessInformation lpProcessInformation
    );

    [StructLayout(LayoutKind.Sequential)]
    internal sealed class ProcessInformation
    {
        public IntPtr hProcess = IntPtr.Zero;
        public IntPtr hThread = IntPtr.Zero;
        public uint dwProcessId = 0;
        public uint dwThreadId = 0;
    }
}