using System.Runtime.InteropServices;

namespace X11;

public class Xutil
{
    /// <summary>
    /// Free a previously allocated XImage.
    /// </summary>
    /// <param name="XImage">The XImage structure to free.</param>
    /// <returns>non-zero on success, zero on failure.</returns>
    public static Status XDestroyImage(ref XImage xImage)
    {
        Marshal.FreeHGlobal(xImage.data);
        Marshal.FreeHGlobal(xImage.obdata);
        return 0;
    }
}
