using System.Runtime.InteropServices;

namespace X11;

public partial class Xcb
{
    public enum Event : byte
    {
        KeyPress = 2,
        KeyRelease = 3,
        ButtonPress = 4,
        ButtonRelease = 5,
        MotionNotify = 6,
        EnterNotify = 7,
        LeaveNotify = 8,
        FocusIn = 9,
        FocusOut = 10,
        KeymapNotify = 11,
        Expose = 12,
        GraphicsExpose = 13,
        NoExpose = 14,
        VisibilityNotify = 15,
        CreateNotify = 16,
        DestroyNotify = 17,
        UnmapNotify = 18,
        MapNotify = 19,
        MapRequest = 20,
        ReparentNotify = 21,
        ConfigureNotify = 22,
        ConfigureRequest = 23,
        GravityNotify = 24,
        ResizeRequest = 25,
        CirculateNotify = 26,
        CirculateRequest = 27,
        PropertyNotify = 28,
        SelectionClear = 29,
        SelectionRequest = 30,
        SelectionNotify = 31,
        ColormapNotify = 32,
        ClientMessage = 33,
        MappingNotify = 34,
        GenericEvent = 35,
        LASTEvent = 36
    }

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public unsafe struct GenericEvent
    {
        public Event response_type;
        private byte pad0;
        public ushort sequence;
        private fixed uint pad[7];
        public uint full_sequence;
    }

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public unsafe struct CreateNotifyEvent
    {
        public Event response_type;
        public byte pad0;
        public ushort sequence;
        public Window* parent;
        public Window* window;
        public short x;
        public short y;
        public ushort width;
        public ushort height;
        public ushort border_width;
        public byte override_redirect;
        public byte pad1;

        public static explicit operator CreateNotifyEvent(GenericEvent v)
        {
            return *(CreateNotifyEvent*)&v;
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public unsafe struct DestroyNotifyEvent
    {
        public Event response_type;
        public byte pad0;
        public ushort sequence;
        public Window* @event;
        public Window* window;

        public static explicit operator DestroyNotifyEvent(GenericEvent v)
        {
            return *(DestroyNotifyEvent*)&v;
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public unsafe struct MapNotifyEvent
    {
        public Event response_type;
        public byte pad0;
        public ushort sequence;
        public Window* @event;
        public Window* window;
        public byte override_redirect;
        private fixed byte pad1[3];

        public static explicit operator MapNotifyEvent(GenericEvent v)
        {
            return *(MapNotifyEvent*)&v;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MapRequestEvent
    {
        public Event response_type;
        public byte pad0;
        public ushort sequence;
        public Window* @event;
        public Window* window;


        public static explicit operator MapRequestEvent(GenericEvent v)
        {
            return *(MapRequestEvent*)&v;
        }
    }
}
