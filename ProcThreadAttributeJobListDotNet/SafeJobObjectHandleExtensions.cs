using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcThreadAttributeJobListDotNet;

public static class SafeJobObjectHandleExtensions
{
    public static Process CreateAssociatedProcess(
        this SafeJobObjectHandle safeHandle, string fileName, string? argument = null)
    {
        nuint size = 0;

        // "First, call this function with the dwAttributeCount parameter set to the maximum number of attributes
        // you will be using and the lpAttributeList to NULL ... This initial call will return an error by design."
        if (InitializeProcThreadAttributeList(IntPtr.Zero, 1, 0, ref size))
            throw new InvalidOperationException($"{nameof(InitializeProcThreadAttributeList)} should have failed");

        var attributeList = Marshal.AllocHGlobal((int)size);

        try
        {
            try
            {
                if (!InitializeProcThreadAttributeList(attributeList, 1, 0, ref size))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

                var handle = safeHandle.DangerousGetHandle();

                if (!UpdateProcThreadAttribute(
                        attributeList, 0, (nuint)ProcThreadAttribute.JobList,
                        ref handle, (nuint)IntPtr.Size, IntPtr.Zero, IntPtr.Zero))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

                // Startup Info Ex!
                throw new NotImplementedException();
            }
            finally
            {
                // delete proc list
            }
        }
        finally
        {
            Marshal.FreeHGlobal(attributeList);
        }
    }

    [DllImport(Constants.Kernel32DllName, CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool CreateProcess(
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

    [DllImport(Constants.Kernel32DllName, SetLastError = true)]
    internal static extern bool InitializeProcThreadAttributeList(
        IntPtr attributeList, uint attributeCount, uint flags, ref nuint lpSize);

    [DllImport(Constants.Kernel32DllName, SetLastError = true)]
    internal static extern bool UpdateProcThreadAttribute(IntPtr attributeList, uint flags,
        nuint attribute, ref IntPtr value, nuint cbSize, IntPtr previousValue, IntPtr returnSize);
}