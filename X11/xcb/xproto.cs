using System;
using System.Runtime.InteropServices;

namespace X11;

public partial class Xcb
{
    public enum XcbEventMask : int
    {
        XCB_EVENT_MASK_NO_EVENT = 0,
        XCB_EVENT_MASK_KEY_PRESS = 1,
        XCB_EVENT_MASK_KEY_RELEASE = 2,
        XCB_EVENT_MASK_BUTTON_PRESS = 4,
        XCB_EVENT_MASK_BUTTON_RELEASE = 8,
        XCB_EVENT_MASK_ENTER_WINDOW = 16,
        XCB_EVENT_MASK_LEAVE_WINDOW = 32,
        XCB_EVENT_MASK_POINTER_MOTION = 64,
        XCB_EVENT_MASK_POINTER_MOTION_HINT = 128,
        XCB_EVENT_MASK_BUTTON_1_MOTION = 256,
        XCB_EVENT_MASK_BUTTON_2_MOTION = 512,
        XCB_EVENT_MASK_BUTTON_3_MOTION = 1024,
        XCB_EVENT_MASK_BUTTON_4_MOTION = 2048,
        XCB_EVENT_MASK_BUTTON_5_MOTION = 4096,
        XCB_EVENT_MASK_BUTTON_MOTION = 8192,
        XCB_EVENT_MASK_KEYMAP_STATE = 16384,
        XCB_EVENT_MASK_EXPOSURE = 32768,
        XCB_EVENT_MASK_VISIBILITY_CHANGE = 65536,
        XCB_EVENT_MASK_STRUCTURE_NOTIFY = 131072,
        XCB_EVENT_MASK_RESIZE_REDIRECT = 262144,
        XCB_EVENT_MASK_SUBSTRUCTURE_NOTIFY = 524288,
        XCB_EVENT_MASK_SUBSTRUCTURE_REDIRECT = 1048576,
        XCB_EVENT_MASK_FOCUS_CHANGE = 2097152,
        XCB_EVENT_MASK_PROPERTY_CHANGE = 4194304,
        XCB_EVENT_MASK_COLOR_MAP_CHANGE = 8388608,
        XCB_EVENT_MASK_OWNER_GRAB_BUTTON = 16777216
    }

    public enum XcbCW : int
    {
        XCB_CW_BACK_PIXMAP = 1,
        XCB_CW_BACK_PIXEL = 2,
        XCB_CW_BORDER_PIXMAP = 4,
        XCB_CW_BORDER_PIXEL = 8,
        XCB_CW_BIT_GRAVITY = 16,
        XCB_CW_WIN_GRAVITY = 32,
        XCB_CW_BACKING_STORE = 64,
        XCB_CW_BACKING_PLANES = 128,
        XCB_CW_BACKING_PIXEL = 256,
        XCB_CW_OVERRIDE_REDIRECT = 512,
        XCB_CW_SAVE_UNDER = 1024,
        XCB_CW_EVENT_MASK = 2048,
        XCB_CW_DONT_PROPAGATE = 4096,
        XCB_CW_COLORMAP = 8192,
        XCB_CW_CURSOR = 16384
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XcbQueryTreeReplyT
    {
        public byte response_type;
        private byte pad0;
        public ushort sequence;
        public uint length;
        public Window* root;
        public Window* parent;
        public ushort children_len;
        private fixed byte pad1[14];
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_query_tree")]
    public static unsafe partial XcbQueryTreeCookie XcbQueryTree(IntPtr Connection, Window* Window);

    [LibraryImport("libxcb", EntryPoint = "xcb_query_tree_reply")]
    private static partial IntPtr XcbQueryTreeReply
        (IntPtr Connection, XcbQueryTreeCookie cookie, ref IntPtr error);

    public unsafe static XcbQueryTreeReplyT? QueryTreeReply
        (IntPtr Connection, XcbQueryTreeCookie Cookie, out XcbGenericError? Error)
    {
        IntPtr err = IntPtr.Zero;
        var reply = XcbQueryTreeReply(Connection, Cookie, ref err);
        if (reply == IntPtr.Zero)
        {
            Error = Marshal.PtrToStructure<XcbGenericError>(err);
            return new XcbQueryTreeReplyT();
        }
        else
        {
            Error = new XcbGenericError();
            return Marshal.PtrToStructure<XcbQueryTreeReplyT>(reply);
        }
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_query_tree_children_length")]
    public static partial int XcbQueryTreeChildrenLength(in XcbQueryTreeReplyT Reply);


    [LibraryImport("libxcb", EntryPoint = "xcb_query_tree_children")]
    private static partial IntPtr XcbQueryTreeChildren(in XcbQueryTreeReplyT Reply);

    [StructLayout(LayoutKind.Sequential)]
    public struct XcbVoidCookie
    {
        public uint sequence;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XcbQueryTreeCookie
    {
        public uint sequence;
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_change_window_attributes")]
    public unsafe static partial XcbVoidCookie XcbChangeWindowAttributes(IntPtr Connection, Window* Window,
        uint ValueMask, IntPtr ValueList);

    [StructLayout(LayoutKind.Sequential, Size = (9 * sizeof(uint)))]
    public struct XcbGenericError
    {
        public byte response_type;
        public byte error_code;
        public ushort sequence;
        public uint resource_id;
        public ushort minor_code;
        public byte major_code;
        // followed by several bytes worth of padding
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_request_check")]
    private static partial IntPtr XcbRequestCheck(IntPtr Connection, XcbVoidCookie Cookie);
    public static XcbGenericError? RequestCheck(IntPtr Connection, XcbVoidCookie Cookie)
    {
        var err = XcbRequestCheck(Connection, Cookie);
        return (err == IntPtr.Zero) ? new XcbGenericError?() : Marshal.PtrToStructure<XcbGenericError>(err);
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XcbScreen
    {
        public Window* root;
        public uint default_colormap;
        public uint white_pixel;
        public uint black_pixel;
        public uint current_input_masks;
        public ushort width_in_pixels;
        public ushort height_in_pixels;
        public ushort width_in_millimeters;
        public ushort height_in_millimeters;
        public ushort min_installed_maps;
        public ushort max_installed_maps;
        public uint root_visual;
        public char backing_stores;
        public char save_unders;
        public char root_depth;
        public char allowed_depths_len;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XcbScreenIterator
    {
        public IntPtr data;
        public int rem;
        public int index;
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_change_window_attributes_checked")]
    public unsafe static partial XcbVoidCookie XcbChangeWindowAttributesChecked(IntPtr Connection,
        Window* Window, XcbCW value_mask, ref XcbEventMask values);

    [LibraryImport("libxcb", EntryPoint = "xcb_grab_server_checked")]
    private static partial XcbVoidCookie XcbGrabServerChecked(IntPtr Connection);
    public static void GrabServer(IntPtr Connection)
    {
        var cookie = XcbGrabServerChecked(Connection);
        XcbGenericError? Error;

        if ((Error = RequestCheck(Connection, cookie)).HasValue)
        {
            throw new Exception($"Failed to grab the X server: code {Error.Value.error_code}");
        }
    }

    [LibraryImport("libxcb", EntryPoint = "xcb_ungrab_server_checked")]
    private static partial XcbVoidCookie XcbUngrabServerChecked(IntPtr Connection);
    public static void UngrabServer(IntPtr Connection)
    {
        var cookie = XcbUngrabServerChecked(Connection);
        XcbGenericError? Error;

        if ((Error = RequestCheck(Connection, cookie)).HasValue)
        {
            throw new Exception($"Failed to release the X server: code {Error.Value.error_code}");
        }
    }


    public unsafe static int[] Children(IntPtr Connection, Window* window)
    {
        var cookie = XcbQueryTree(Connection, window);
        var qt = QueryTreeReply(Connection, cookie, out var Error);

        if (qt.HasValue)
        {
            var v = qt.Value;
            var pChildren = XcbQueryTreeChildren(in v);
            var n = XcbQueryTreeChildrenLength(in v);

            Console.WriteLine($"Window {(nint)window} has {n} children");

            var Children = new int[n];
            Marshal.Copy(pChildren, Children, 0, n);
            return Children;
        }
        else
        {
            throw new Exception($"Unable to query tree: error code {(Error == null ? " null" : Error.Value.error_code.ToString())}");
        }
    }
}
