using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace samplekeyboard
{
    public  class Program
    {
        [DllImport("user32.dll")]
        private static extern bool InjectKeyboardInput(ref tagKEYBDINPUT input, uint count);

        public static void Main(string[] args)
        {
            Thread.Sleep(1000);
            TypeKey(false, ScanCode.LSHIFT);
            TypeKey(false, ScanCode.KEY_A);
            TypeKey(true, ScanCode.LSHIFT);
        }

        public static void TypeKey(bool up, ScanCode code)
        {
            tagKEYBDINPUT input = new tagKEYBDINPUT()
            {
                wScan =  code
            };
            if (up)
                input.dwFlags = KeyEventFlags.KEYEVENTF_KEYUP;
            InjectKeyboardInput(ref input, 1);
        }
    }

    [Flags]
    public enum KeyEventFlags : uint
    {
        KEYEVENTF_EXTENDEDKEY = 0x0001u,
        KEYEVENTF_KEYUP = 0x0002u,
        KEYEVENTF_SCANCODE = 0x0008u,
        KEYEVENTF_UNICODE = 0x0004u
    }

    public struct tagKEYBDINPUT
    {
        /// <summary>
        /// A virtual-key code.
        /// The code must be a value in the range 1 to 254.
        /// If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.
        /// </summary>
        public ushort wVk; // 1 - 254

        /// <summary>
        /// A hardware scan code for the key.
        /// If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.
        /// </summary>
        public ScanCode wScan;

        /// <summary>
        /// Specifies various aspects of a keystroke.
        /// </summary>
        public KeyEventFlags dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// If this parameter is zero, the system will provide its own time stamp.
        /// </summary>
        public uint time;

        /// <summary>
        /// An additional value associated with the keystroke.
        /// Use the GetMessageExtraInfo function to obtain this information.
        /// </summary>
        public ulong dwExtraInfo;
    }

    /// <summary>
    ///     ''' The OEM, device-dependent identifier For the key On the keyboard.
    ///     ''' A keyboard generates two scan codes When the user types a key—one 
    ///     ''' When the user presses the key And another When the user releases the key.
    ///     ''' </summary>
    public enum ScanCode : ushort
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 11,
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0
    }

}
