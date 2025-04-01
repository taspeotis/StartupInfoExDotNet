namespace ProcThreadAttributeJobListDotNet;

internal enum ProcThreadAttribute : uint
{
    ParentProcess = 131072U,
    HandleList = 131074U,
    GroupAffinity = 196611U,
    PreferredNode = 131076U,
    IdealProcessor = 196613U,
    UmsThread = 196614U,
    MitigationPolicy = 131079U,
    SecurityCapabilities = 131081U,
    ProtectionLevel = 131083U,
    MachineType = 131097U,
    EnableOptionalXstateFeatures = 196635U,
    JobList = 131085U,
    ChildProcessPolicy = 131086U,
    DesktopAppPolicy = 131090U
}