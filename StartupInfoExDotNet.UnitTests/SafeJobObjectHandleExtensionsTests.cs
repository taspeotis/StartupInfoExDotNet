namespace StartupInfoExDotNet.UnitTests;

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
        using var process = safeJobObjectHandle.CreateAssociatedProcess("notepad.exe");
    }
    
    /*
     * + internalsVisibleTo
     * BOOL IsProcessInJob(
  [in]           HANDLE ProcessHandle,
  [in, optional] HANDLE JobHandle,
  [out]          PBOOL  Result
);
     */
}