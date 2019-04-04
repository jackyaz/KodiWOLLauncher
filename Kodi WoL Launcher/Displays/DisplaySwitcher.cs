using System.Diagnostics;
using System.Threading;

namespace Kodi_WoL_Launcher.Displays
{
    public enum DisplayMode { Internal, Extend, External, Clone } //types of Display mode available in Windows.

    public static class DisplaySwitcher
    {
        /// <summary>
        /// This function will configure your Windows desktop/monitor arrangement.
        /// </summary>
        /// <param name="displaymode">Display mode to switch Windows to.</param>
        public static void SwitchDisplays(DisplayMode displaymode)
        {
            ProcessStartInfo _psi = new ProcessStartInfo(@"C:\Windows\Sysnative\DisplaySwitch.exe"); //create new instance of ProcessStartInfo with filename to be run.
            _psi.WindowStyle = ProcessWindowStyle.Hidden; //set process to be hidden from user.
            _psi.Arguments = "/" + displaymode.ToString(); //set argument switch to the DisplayType parameter.

            Process _p = new Process(); //create new instance of Process.
            _p.StartInfo = _psi; //assign our start info to process.
            _p.Start(); //start the process.

            _p.WaitForExit(10000); //wait for maximum of 10 seconds for process to finish.

            _psi = null; //dispose of ProcessStartInfo instance.
            _p.Dispose(); //dispose of Process instance.

            Thread.Sleep(5000); //wait 5 seconds to ensure it's done.
        }
    }
}
