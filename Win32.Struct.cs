using System.Runtime.InteropServices;

namespace Win32Api
{
    public static partial class Win32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MONITORINFOEX
        {
            public int cbSize;
            public RECT rcMonitor;  // ディスプレイの領域
            public RECT rcWork; // ディスプレイ内のタスクバーなどを除いた領域
            public uint dwFlags;    // プライマリディスプレイかどうか(1: プライマリ、0: 非プライマリ)
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szDevice; // 名前("\\.\DISPLAY1"など)
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        // RAWHID は可変長構造体のため、C# の struct では正確に表現できない。
        // RAWINPUT の union においても RAWHID は記載しない。
        // HID データを扱う場合は、RAWINPUTHEADER の後ろのメモリを手動で読み取る必要がある。
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct RAWINPUT
        {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;

            // union の先頭
            [FieldOffset(16)]
            public RAWMOUSE mouse;

            [FieldOffset(16)]
            public RAWKEYBOARD keyboard;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RAWINPUTHEADER
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWKEYBOARD
        {
            public ushort MakeCode;      // USHORT
            public ushort Flags;         // USHORT
            public ushort Reserved;      // USHORT
            public ushort VKey;          // USHORT
            public uint Message;         // UINT
            public uint ExtraInformation; // ULONG
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct RAWMOUSE
        {
            // USHORT usFlags;
            [FieldOffset(0)]
            public ushort usFlags;

            // union { ULONG ulButtons; struct { USHORT usButtonFlags; USHORT usButtonData; }; };

            // ULONG ulButtons;
            [FieldOffset(4)]
            public uint ulButtons;

            // USHORT usButtonFlags;
            [FieldOffset(4)]
            public ushort usButtonFlags;

            // USHORT usButtonData;
            [FieldOffset(6)]
            public ushort usButtonData;

            // ULONG ulRawButtons;
            [FieldOffset(8)]
            public uint ulRawButtons;

            // LONG lLastX;
            [FieldOffset(12)]
            public int lLastX;

            // LONG lLastY;
            [FieldOffset(16)]
            public int lLastY;

            // ULONG ulExtraInformation;
            [FieldOffset(20)]
            public uint ulExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public uint wFunc;
            public string pFrom;
            public string pTo;
            public ushort fFlags;
            public int fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public WndProcDelegate lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public IntPtr lpszMenuName; // メニュー名または MAKEINTRESOURCE なリソース ID
            public IntPtr lpszClassName;
            public IntPtr hIconSm;
        }
    }
}
