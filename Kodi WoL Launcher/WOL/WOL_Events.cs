using System;

namespace Kodi_WoL_Launcher.WOL
{
    public enum PacketStatus { Received, Stop, Error, ApplicationExit }

    public static class WOL_Events
    {
        public delegate void WOLEventHandler(object sender, WOLEventArgs e);
        public static event WOLEventHandler OnPacketReceived;

        public static void PacketReceived(PacketStatus packetstatus)
        {
            // Make sure someone is listening to event
            if (OnPacketReceived == null) return;

            WOLEventArgs args = new WOLEventArgs(packetstatus);
            OnPacketReceived(null, args);
        }
    }

    /// <summary>
    /// Custom event argument class derived from base event argument.
    /// </summary>
    public class WOLEventArgs : EventArgs
    {
        public PacketStatus Status { get; private set; }

        /// <summary>
        /// Constructor for event arguments, accepts PacketStatus to determine action to take.
        /// </summary>
        /// <param name="packetreceived">Various states packet can have.</param>
        public WOLEventArgs(PacketStatus packetstatus)
        {
            Status = packetstatus; //set property from constructor parameter.
        }
    }
}
