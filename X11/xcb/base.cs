using System;
using System.Runtime.InteropServices;

namespace X11;

public partial class Xcb
{
    public struct Window { };

    /// <summary>
    /// Establish an XCB connection to X11
    /// </summary>
    /// <param name="DisplayName">Name of the display to connect to. If NULL, connect to the default display</param>
    /// <param name="ScreenNumber">Pointer to the screen number to connect to. Defaults to zero where this is NULL</param>
    /// <returns>A pointer to the connection object. Always returns non-null; check the result with xcb_connection_has_error()</returns>
    [LibraryImport("libxcb", EntryPoint = "xcb_connect",StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr XcbConnect(string DisplayName, IntPtr ScreenNumber);

    [LibraryImport("libxcb", EntryPoint = "xcb_disconnect")]
    public static partial void XcbDisconnect(IntPtr Connection);

    /// <summary>
    /// Return codes for xcb_connection_has_error()
    /// </summary>
    public enum XCBConnectionError : int
    {
        SUCCESS = 0,
        CONN_ERROR = 1,
        CON_CLOSED_EXTENSION_NOT_SUPPORTED = 2,
        CON_CLOSED_MEM_INSUFFICIENT = 3,
        CON_CLOSED_REQ_LEN_EXCEEDED = 4,
        CON_CLOSED_PARSE_ERROR = 5,
        CON_CLOSED_INVALID_SCREEN = 6,
    }

    /// <summary>
    /// Check whether an XCB connection was successfully established, or not.
    /// </summary>
    /// <param name="Connection">Pointer to a connection object returned by xcb_connect()</param>
    /// <returns>0 on success, >0 on failure.</returns>
    [LibraryImport("libxcb", EntryPoint = "xcb_connection_has_error")]
    public static partial XCBConnectionError XcbConnectionHasError(IntPtr Connection);

    [LibraryImport("libxcb", EntryPoint = "xcb_get_setup")]
    public static partial IntPtr XcbGetSetup(IntPtr Connection);

    [LibraryImport("libxcb", EntryPoint = "xcb_setup_roots_iterator")]
    public static partial XcbScreenIterator XcbSetupRootsIterator(IntPtr Setup);

    /// <summary>
    /// Block until the next event is received (or the connection to X11 is lost)
    /// </summary>
    /// <param name="Connection">A pointer to an opaque connection structure</param>
    /// <returns>The next event received (or null on disconnection)</returns>
    [LibraryImport("libxcb", EntryPoint = "xcb_wait_for_event")]
    private static partial IntPtr XcbWaitForEvent(IntPtr Connection);

    public static GenericEvent? WaitForEvent(IntPtr Connection)
    {
        var e = XcbWaitForEvent(Connection);
        return (e == IntPtr.Zero) ? new GenericEvent?() : Marshal.PtrToStructure<GenericEvent>(e);
    }

}
