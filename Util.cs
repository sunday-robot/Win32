using System.Runtime.InteropServices;

namespace Win32
{
    public static class Util
    {
        public static void ThrowWin32Exception(string apiName)
        {
            var errorCode = Marshal.GetLastWin32Error();
            throw new InvalidOperationException($"{apiName} is failed. Win32Error = {errorCode}");
        }
    }
}
