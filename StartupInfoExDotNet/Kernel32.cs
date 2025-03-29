using System.Runtime.InteropServices;
using System.Text;

namespace StartupInfoExDotNet;

internal static class Kernel32
{
    private const string DllName = "kernel32.dll";

    [DllImport(DllName, CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool CreateProcess(
        string? lpApplicationName,
        string? lpCommandLine,
        IntPtr lpProcessAttributes,
        IntPtr lpThreadAttributes,
        bool bInheritHandles,
        uint dwCreationFlags,
        IntPtr lpEnvironment,
        [MarshalAs(UnmanagedType.LPTStr)] string? lpCurrentDirectory,
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
    
    
// marshall this plus static Start method(IEnumerable attributes)
    public class StartupInfoEx
    {
    
    }

}