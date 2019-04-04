using System;
using System.Text;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Kodi_WoL_Launcher.WOL
{
    /// <summary>
    /// This class is used for the listening for incoming WOL packets and raising events as required.
    /// </summary>
    public class WOL_Listener
    {
        private BackgroundWorker bgListenforWOL; //declare BackgroundWorker variable
        private WOL_Socket _wolsock; //declare WOL_Socket variable
        private PacketStatus packetstatus;
        private int portno;

        public WOL_Listener()
        {
            bgListenforWOL = new BackgroundWorker();
            bgListenforWOL.WorkerSupportsCancellation = true;
            bgListenforWOL.WorkerReportsProgress = true;
            bgListenforWOL.DoWork += new DoWorkEventHandler(bgListenforWOL_DoWork);
            bgListenforWOL.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgListenforWOL_RunWorkerCompleted);
        }

        public void StartListener(int _portno)
        {
            this.portno = _portno;
            Console.WriteLine("Listener starting on port number: " + portno.ToString());
            bgListenforWOL.RunWorkerAsync();
        }

        public void StopListener(PacketStatus _packetstatus)
        {
            packetstatus = _packetstatus;

            if (bgListenforWOL.IsBusy)
            {
                bgListenforWOL.CancelAsync();
                _wolsock.Close();
            }

            while (bgListenforWOL.IsBusy)
            {
                Application.DoEvents();
            }
        }

        public void RestartListener(PacketStatus _packetstatus,int _portno)
        {
            this.portno = _portno;
            StopListener(_packetstatus);
            StartListener(this.portno);
        }

        /// <summary>
        /// This function contains the actions that will be carried out on the background thread.
        /// </summary>
        /// <param name="sender">Object which triggers this event handler, typically a Background Worker</param>
        /// <param name="e">Arguments pased to the event handler</param>
        private void bgListenforWOL_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int portno = this.portno;
                _wolsock = new WOL_Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp, portno);
                Console.WriteLine("Ready to receive...");
                _wolsock.ReceiveWOLPacket();
                packetstatus = PacketStatus.Received;
                Console.WriteLine(_wolsock.IEP.Address.ToString()); //print sender IP address
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.Interrupted)
                {
                    e.Cancel = true; //set DoWork result as cancelled
                }
            }
        }

        /// <summary>
        /// This functions that will be carried out on the Background Worker's calling thread once DoWork has exited.
        /// </summary>
        /// <param name="sender">Object which triggers this event handler, typically a Background Worker</param>
        /// <param name="e">Arguments pased to the event handler</param>
        private void bgListenforWOL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WOL_Events.PacketReceived(packetstatus);
        }
    }
}
