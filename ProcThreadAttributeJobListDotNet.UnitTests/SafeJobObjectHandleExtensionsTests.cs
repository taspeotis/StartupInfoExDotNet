using System.Runtime.InteropServices;

namespace ProcThreadAttributeJobListDotNet.UnitTests;

public sealed class SafeJobObjectHandleExtensionsTests
{
    [Fact]
    public void CreateAssociatedProcess_Creates_AssociatedProcess()
    {
        var extendedLimitInformation = new JobObjectExtendedLimitInformation
        {
            BasicLimitInformation = { LimitFlags = JobObjectLimit.KillOnJobClose }
        };

        using var safeJobObjectHandle = extendedLimitInformation.CreateJobObject();
        using var process = safeJobObjectHandle.CreateAssociatedProcess(@"C:\Windows\System32\notepad.exe");
        var result = false;

        Assert.True(IsProcessInJob(process.SafeHandle, safeJobObjectHandle, ref result));
        Assert.True(result);
    }

    [DllImport(Constants.Kernel32DllName, SetLastError = true)]
    private static extern bool IsProcessInJob(SafeHandle processHandle, SafeHandle jobHandle, ref bool result);
}