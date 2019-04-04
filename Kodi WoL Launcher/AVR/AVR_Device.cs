using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;

namespace Kodi_WoL_Launcher.AVR
{
    /// <summary>
    /// Class used to define an AVR Device
    /// </summary>
    public class AVR_Device
    {
        private string ipaddress; //ip address of the AVR device
        private int portno; //port number for YNCA commands on the AVR device

        /// <summary>
        /// Constructor for AVR device, used to create new instance of an AVR device to interact with.
        /// </summary>
        /// <param name="_ipaddress">The IP address of the AVR device on the local network</param>
        /// <param name="_portno">Port number that AVR device uses to receive YNCA commands</param>
        public AVR_Device(string _ipaddress, int _portno)
        {
            ipaddress = _ipaddress;
            portno = _portno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="requireresponse"></param>
        /// <returns></returns>
        private string SendCommandToAvr(string command, bool requireresponse)
        {
            TcpClient tcpclnt = new TcpClient();

            tcpclnt.Connect(ipaddress, portno);

            string str = command + Environment.NewLine;

            byte[] data = new byte[1024];
            string responseData = "";

            NetworkStream networkStream = tcpclnt.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(str);
            streamWriter.Flush();

            if (requireresponse)
            {
                //Get the response
                int recv = networkStream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, recv);
            }

            networkStream.Close();

            tcpclnt.Close();

            return responseData;
        }

        public void PowerOnTV()
        {
            SendCommandToAvr("@MAIN:SCENE=Scene 2", false);
            Thread.Sleep(10000);
        }

        public void SetInput(string inputname)
        {
            SendCommandToAvr("@MAIN:INP=" + inputname, false);
            Thread.Sleep(5000);
        }
    }
}