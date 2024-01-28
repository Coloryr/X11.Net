using System;
using System.Runtime.InteropServices;

namespace X11;

public partial class Xmu
{
    [LibraryImport("libXmu")]
    public static partial Atom XmuInternAtom(IntPtr display, IntPtr atomPtr);

    [LibraryImport("libXmu", StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr XmuMakeAtom(string name);
}
