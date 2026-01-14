using System.Runtime.InteropServices;
using static Win32.Win32Struct;

namespace Win32
{
    public static class Win32Delagate
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
