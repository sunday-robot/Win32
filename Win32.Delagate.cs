using System.Runtime.InteropServices;

namespace Win32Api
{
    public static partial class Win32
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
