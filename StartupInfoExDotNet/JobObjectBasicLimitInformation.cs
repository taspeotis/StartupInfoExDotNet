using System.Runtime.InteropServices;

namespace StartupInfoExDotNet;

[StructLayout(LayoutKind.Sequential)]
public sealed class JobObjectBasicLimitInformation
{
    public static SafeHandle CreateJobObject()
    {
        var handle = CreateJobObject(IntPtr.Zero, null);

        if (handle == IntPtr.Zero)
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

        return new SafeHandleZeroIsInvalid(handle);
    }

    internal long PerProcessUserTimeLimit;

    internal long PerJobUserTimeLimit;

    internal JobObjectLimit LimitFlags;

    internal nuint MinimumWorkingSetSize;

    internal nuint MaximumWorkingSetSize;

    internal uint ActiveProcessLimit;

    internal nuint Affinity;

    internal uint PriorityClass;

    internal uint SchedulingClass;

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string? lpName);

    /*[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool SetInformationJobObject(IntPtr hJob,
        JOBOBJECTINFOCLASS JobObjectInfoClass, IntPtr lpJobObjectInfo,
        uint cbJobObjectInfoLength);*/
}