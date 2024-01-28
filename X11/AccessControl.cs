using System;
using System.Runtime.InteropServices;

namespace X11;

[StructLayout(LayoutKind.Sequential)]
public struct XHostAddress
{
    public int family;
    public int length;
    public IntPtr address;
}

public partial class Xlib
{
    [LibraryImport("libX11")]
    public static partial Status XAddHost(IntPtr display, ref XHostAddress host);

    [LibraryImport("libX11")]
    public static partial Status XAddHosts(IntPtr display, ref XHostAddress hosts, int num_hosts);

    [DllImport("libX11")]
    public static extern ref XHostAddress XListHosts(IntPtr display, ref int nhosts_return, ref bool state_return);

    [LibraryImport("libX11")]
    public static partial Status XRemoveHost(IntPtr display, ref XHostAddress host);

    [LibraryImport("libX11")]
    public static partial Status XRemoveHosts(IntPtr display, ref XHostAddress hosts, int num_hosts);

    [LibraryImport("libX11")]
    public static partial Status XSetAccessControl(IntPtr display, int mode);

    [LibraryImport("libX11")]
    public static partial Status XEnableAccessControl(IntPtr display);

    [LibraryImport("libX11")]
    public static partial Status XDisableAccessControl(IntPtr display);
}
