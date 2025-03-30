namespace StartupInfoExDotNet.UnitTests;

public sealed class JobObjectExtendedLimitInformationExtensionsTests
{
    [Fact]
    public void CreateJobObject_Creates_JobObject()
    {
        var extendedLimitInformation = new JobObjectExtendedLimitInformation
        {
            BasicLimitInformation = { LimitFlags = JobObjectLimit.KillOnJobClose }
        };

        var safeHandle = extendedLimitInformation.CreateJobObject();

        using (safeHandle)
        {
            Assert.False(safeHandle.IsClosed);
            Assert.False(safeHandle.IsInvalid);
        }

        Assert.True(safeHandle.IsClosed);
    }
}