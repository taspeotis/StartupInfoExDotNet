namespace StartupInfoExDotNet.UnitTests;

public sealed class JobObjectBasicLimitInformationTests
{
    [Fact]
    public void CreateJobObject_Creates_JobObject()
    {
        var safeHandle = JobObjectBasicLimitInformation.CreateJobObject();

        using (safeHandle)
        {
            Assert.False(safeHandle.IsClosed);
            Assert.False(safeHandle.IsInvalid);
        }

        Assert.True(safeHandle.IsClosed);
    }
}