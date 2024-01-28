using System;
using System.Runtime.InteropServices;

namespace X11;

using Window = nint;

public enum ScreenSaverExposures : int
{
    DontAllowExposures = 0,
    AllowExposures = 1,
    DefaultExposures = 2,
}

public enum ScreenSaverMode : int
{
    ScreenSaverReset = 0,
    ScreenSaverActive = 1,
}

public enum ScreenSaverBlanking : int
{
    DontPreferBlanking = 0,
    PreferBlanking = 1,
    DefaultBlanking = 2,
}

[StructLayout(LayoutKind.Sequential)]
public struct XScreenSaverInfo
{
    public Window window;
    public int state;
    public int kind;
    public ulong til_or_since;
    public ulong idle;
    public ulong eventMask;
}

public partial class Xlib
{
    [LibraryImport("libX11")]
    public static partial Status XSetScreenSaver(IntPtr display, int timeout, int interval, ScreenSaverBlanking prefer_blanking,
        ScreenSaverExposures allow_exposures);

    [LibraryImport("libX11")]
    public static partial Status XForceScreenSaver(IntPtr display, ScreenSaverMode mode);

    [LibraryImport("libX11")]
    public static partial Status XActivateScreenSaver(IntPtr display);

    [LibraryImport("libX11")]
    public static partial Status XResetScreenSaver(IntPtr display);

    [LibraryImport("libX11")]
    public static partial Status XGetScreenSaver(IntPtr display, ref int timeout_return, ref int interval_return,
        ref ScreenSaverBlanking prefer_blanking_return, ref ScreenSaverExposures allow_exposures_return);

    [LibraryImport("libXss")]
    public static partial Status XScreenSaverQueryInfo(IntPtr display, Window drawable, ref XScreenSaverInfo saver_info);
}
