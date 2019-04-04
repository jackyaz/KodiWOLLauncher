using System.Net.Sockets;
using System.Net;

namespace Kodi_WoL_Launcher.WOL
{
    /// <summary>
    /// This class is used for accepting Wake on LAN packets broadcast on the local network.
    /// </summary>
    public class WOL_Socket : Socket
    {
        #region Variables and Properties
        private IPEndPoint iep;

        /// <summary>
        /// The IPEndPoint of the socket i.e. the sender of the packet.
        /// </summary>
        public IPEndPoint IEP
        {
            get { return iep; }
            set { iep = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for WOL Socket class, dervied from base constructor for Socket.
        /// </summary>
        /// <param name="a">Address family of address socket will handle.</param>
        /// <param name="s">Type of socket to create, for WOL, we use DGram.</param>
        /// <param name="p">Protocol type, for WOL we use UDP.</param>
        /// <param name="portno">Port number that socket will be bound to.</param>
        public WOL_Socket(AddressFamily a, SocketType s, ProtocolType p, int portno)
            : base(a, s, p)
        {
            IPEndPoint _iep = new IPEndPoint(IPAddress.Any, portno); //create IPEndPoint for any ip address on specified port.
            this.Bind(_iep); //bind IPEndPoint to the socked.
            this.iep = _iep; //set IPEndPoint to local property.
        }

        #endregion

        #region Methods

        /// <summary>
        /// Function used to receive data on the specified port. This will block further thread operations until data is received.
        /// </summary>
        public void ReceiveWOLPacket()
        {
            byte[] data = new byte[1024]; //declare new byte array 1024 bytes in size.
            EndPoint ep = (EndPoint)iep; //convert IPEndPoint to EndPoint.
            int recv = this.ReceiveFrom(data, ref ep); //receive packet on socket.
            this.Close(); //close socket allowing for re-use.
        }

        #endregion
    }
}

