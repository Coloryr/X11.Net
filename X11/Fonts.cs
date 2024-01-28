using System;
using System.Runtime.InteropServices;

namespace X11;

public partial class Xlib
{

    [LibraryImport("libX11")]
    public static partial Status XSetFontPath(IntPtr display, IntPtr directories, int ndirs);

    [LibraryImport("libX11")]
    public static partial IntPtr XGetFontPath(IntPtr display, ref int npaths_return);

    [LibraryImport("libX11")]
    public static partial Status XFreeFontPath(IntPtr list);

    [DllImport("libX11")]
    public static extern IntPtr XListFonts(IntPtr display, string pattern, int maxnames, ref int actual_count_return);

    [LibraryImport("libX11")]
    public static partial Status XFreeFontNames(IntPtr list);

    [LibraryImport("libX11", StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr XListFontsWithInfo(IntPtr display, string pattern, int maxnames,
        ref int count_return, IntPtr info_return);

    [LibraryImport("libX11")]
    public static partial Status XFreeFontInfo(IntPtr names, IntPtr free_info, int actual_count);
}
