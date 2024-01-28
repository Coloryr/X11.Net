﻿using System;
using System.Runtime.InteropServices;

namespace X11;

public enum XID : ulong { }

public enum Status : int
{
    Failure = 0,
}

public enum RequestCodes : int
{
    X_CreateWindow = 1,
    X_ChangeWindowAttributes = 2,
    X_GetWindowAttributes = 3,
    X_DestroyWindow = 4,
    X_DestroySubwindows = 5,
    X_ChangeSaveSet = 6,
    X_ReparentWindow = 7,
    X_MapWindow = 8,
    X_MapSubwindows = 9,
    X_UnmapWindow = 10,
    X_UnmapSubwindows = 11,
    X_ConfigureWindow = 12,
    X_CirculateWindow = 13,
    X_GetGeometry = 14,
    X_QueryTree = 15,
    X_InternAtom = 16,
    X_GetAtomName = 17,
    X_ChangeProperty = 18,
    X_DeleteProperty = 19,
    X_GetProperty = 20,
    X_ListProperties = 21,
    X_SetSelectionOwner = 22,
    X_GetSelectionOwner = 23,
    X_ConvertSelection = 24,
    X_SendEvent = 25,
    X_GrabPointer = 26,
    X_UngrabPointer = 27,
    X_GrabButton = 28,
    X_UngrabButton = 29,
    X_ChangeActivePointerGrab = 30,
    X_GrabKeyboard = 31,
    X_UngrabKeyboard = 32,
    X_GrabKey = 33,
    X_UngrabKey = 34,
    X_AllowEvents = 35,
    X_GrabServer = 36,
    X_UngrabServer = 37,
    X_QueryPointer = 38,
    X_GetMotionEvents = 39,
    X_TranslateCoords = 40,
    X_WarpPointer = 41,
    X_SetInputFocus = 42,
    X_GetInputFocus = 43,
    X_QueryKeymap = 44,
    X_OpenFont = 45,
    X_CloseFont = 46,
    X_QueryFont = 47,
    X_QueryTextExtents = 48,
    X_ListFonts = 49,
    X_ListFontsWithInfo = 50,
    X_SetFontPath = 51,
    X_GetFontPath = 52,
    X_CreatePixmap = 53,
    X_FreePixmap = 54,
    X_CreateGC = 55,
    X_ChangeGC = 56,
    X_CopyGC = 57,
    X_SetDashes = 58,
    X_SetClipRectangles = 59,
    X_FreeGC = 60,
    X_ClearArea = 61,
    X_CopyArea = 62,
    X_CopyPlane = 63,
    X_PolyPoint = 64,
    X_PolyLine = 65,
    X_PolySegment = 66,
    X_PolyRectangle = 67,
    X_PolyArc = 68,
    X_FillPoly = 69,
    X_PolyFillRectangle = 70,
    X_PolyFillArc = 71,
    X_PutImage = 72,
    X_GetImage = 73,
    X_PolyText8 = 74,
    X_PolyText16 = 75,
    X_ImageText8 = 76,
    X_ImageText16 = 77,
    X_CreateColormap = 78,
    X_FreeColormap = 79,
    X_CopyColormapAndFree = 80,
    X_InstallColormap = 81,
    X_UninstallColormap = 82,
    X_ListInstalledColormaps = 83,
    X_AllocColor = 84,
    X_AllocNamedColor = 85,
    X_AllocColorCells = 86,
    X_AllocColorPlanes = 87,
    X_FreeColors = 88,
    X_StoreColors = 89,
    X_StoreNamedColor = 90,
    X_QueryColors = 91,
    X_LookupColor = 92,
    X_CreateCursor = 93,
    X_CreateGlyphCursor = 94,
    X_FreeCursor = 95,
    X_RecolorCursor = 96,
    X_QueryBestSize = 97,
    X_QueryExtension = 98,
    X_ListExtensions = 99,
    X_ChangeKeyboardMapping = 100,
    X_GetKeyboardMapping = 101,
    X_ChangeKeyboardControl = 102,
    X_GetKeyboardControl = 103,
    X_Bell = 104,
    X_ChangePointerControl = 105,
    X_GetPointerControl = 106,
    X_SetScreenSaver = 107,
    X_GetScreenSaver = 108,
    X_ChangeHosts = 109,
    X_ListHosts = 110,
    X_SetAccessControl = 111,
    X_SetCloseDownMode = 112,
    X_KillClient = 113,
    X_RotateProperties = 114,
    X_ForceScreenSaver = 115,
    X_SetPointerMapping = 116,
    X_GetPointerMapping = 117,
    X_SetModifierMapping = 118,
    X_GetModifierMapping = 119,
    X_NoOperation = 127,
}

public enum PropertyMode : int
{
    Replace = 0,
    Prepend = 1,
    Append = 2
}

public partial class Xlib
{
    [LibraryImport("libX11")]
    public static partial void XFree(IntPtr data);
}
