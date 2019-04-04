using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Kodi_WoL_Launcher.Displays
{
    public static class DisplayWaker
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;

        public static void WakeDisplays()
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_MOVE, 0, -1, 0, UIntPtr.Zero);
            Thread.Sleep(5000);
        }
    }
}