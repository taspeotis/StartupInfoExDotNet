using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace ProcThreadAttributeJobListDotNet;

[StructLayout(LayoutKind.Sequential)]
internal sealed class StartupInfoEx
{
    public StartupInfo StartupInfo;

    public IntPtr AttributeList;
}

[StructLayout(LayoutKind.Sequential)]
internal struct StartupInfo
{
    /// <summary>The size of the structure, in bytes.</summary>
    internal uint cb;

    /// <summary>Reserved; must be NULL.</summary>
    internal string? lpReserved;

    /// <summary>
    /// <para>The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string indicates that the string includes both the desktop and window station names. For more information, see [Thread Connection to a Desktop](/windows/desktop/winstation/thread-connection-to-a-desktop).</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal string? lpDesktop;

    /// <summary>For console processes, this is the title displayed in the title bar if a new console window is created. If NULL, the name of the executable file is used as the window title instead. This parameter must be NULL for GUI or console processes that do not create a new console window.</summary>
    internal string? lpTitle;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.</para>
    /// <para>The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create an overlapped window if the <i>x</i> parameter of <b>CreateWindow</b> is CW_USEDEFAULT.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal uint dwX;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.</para>
    /// <para>The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create an overlapped window if the <i>y</i> parameter of <b>CreateWindow</b> is CW_USEDEFAULT.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal uint dwY;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels. Otherwise, this member is ignored.</para>
    /// <para>For GUI processes, this is used only the first time the new process calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create an overlapped window if the <i>nWidth</i> parameter of <b>CreateWindow</b> is CW_USEDEFAULT.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal uint dwXSize;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels. Otherwise, this member is ignored.</para>
    /// <para>For GUI processes, this is used only the first time the new process calls <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-createwindowa">CreateWindow</a> to create an overlapped window if the <i>nHeight</i> parameter of <b>CreateWindow</b> is CW_USEDEFAULT.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal uint dwYSize;

    /// <summary>If <b>dwFlags</b> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer width, in character columns. Otherwise, this member is ignored.</summary>
    internal uint dwXCountChars;

    /// <summary>If <b>dwFlags</b> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer height, in character rows. Otherwise, this member is ignored.</summary>
    internal uint dwYCountChars;

    /// <summary>If <b>dwFlags</b> specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console window is created in a console application. Otherwise, this member is ignored.</summary>
    internal uint dwFillAttribute;

    /// <summary>A bitfield that determines whether certain</summary>
    internal StartupInfoFlags dwFlags;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USESHOWWINDOW, this member can be any of the values that can be specified in the <i>nCmdShow</i> parameter for the <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-showwindow">ShowWindow</a> function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored.</para>
    /// <para>For GUI processes, the first time <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-showwindow">ShowWindow</a> is called, its <i>nCmdShow</i> parameter is ignored <b>wShowWindow</b> specifies the default value. In subsequent calls to <a href="https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-showwindow">ShowWindow</a>, the <b>wShowWindow</b> member is used if the <i>nCmdShow</i> parameter of <b>ShowWindow</b> is set to SW_SHOWDEFAULT.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal ushort wShowWindow;

    /// <summary>Reserved for use by the C Run-time; must be zero.</summary>
    internal ushort cbReserved2;

    /// <summary>Reserved for use by the C Run-time; must be NULL.</summary>
    internal IntPtr lpReserved2;

    /// <summary>
    /// <para>If <b>dwFlags</b> specifies STARTF_USESTDHANDLES, this member is the standard input handle for the process. If STARTF_USESTDHANDLES is not specified, the default for standard input is the keyboard buffer. If <b>dwFlags</b> specifies STARTF_USEHOTKEY, this member specifies a hotkey value that is sent as the <i>wParam</i> parameter of a <a href="https://docs.microsoft.com/windows/win32/inputdev/wm-sethotkey">WM_SETHOTKEY</a> message to the first  eligible top-level window created by the application that owns the process. If the window is created with the WS_POPUP window style, it is not eligible unless the WS_EX_APPWINDOW extended window style is also set. For more information, see <a href="https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-createwindowexa">CreateWindowEx</a>. Otherwise, this member is ignored.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow#members">Read more on docs.microsoft.com</see>.</para>
    /// </summary>
    internal IntPtr hStdInput;

    internal IntPtr hStdOutput;

    internal IntPtr hStdError;
}