using System;
using System.Diagnostics;
using Kodi_WoL_Launcher.Displays;
using Kodi_WoL_Launcher.AVR;

namespace Kodi_WoL_Launcher.Kodi
{
    public class Kodi_App
    {
        AVR_Device _avr;

        public Kodi_App()
        {
            _avr = new AVR_Device("192.168.0.20", 50000);
        }

        public void ConfigureKodi(DisplayMode displaymode, string kodipath)
        {
            DisplayWaker.WakeDisplays();
            _avr.PowerOnTV();
            _avr.SetInput("HDMI4");

            DisplaySwitcher.SwitchDisplays(displaymode);
            Process _kodi = new Process();
            ProcessStartInfo _kodistartinfo = new ProcessStartInfo(kodipath);
            _kodi.StartInfo = _kodistartinfo;
            _kodi.Start();
            _kodi.WaitForExit();
        }

        public void DeConfigureKodi()
        {
            DisplaySwitcher.SwitchDisplays(DisplayMode.External);
            _avr.SetInput("HDMI2");
        }
    }
}
