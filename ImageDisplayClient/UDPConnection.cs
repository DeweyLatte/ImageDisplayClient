using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ImageDisplayClient
{
    public class UDPConnection
    {
        private UdpClient udpClient;

        public UDPConnection(int p_listenPort)
        {
            udpClient = new UdpClient(p_listenPort);
        }

        public List<string> StartListening()
        {
            //Creates an IPEndPoint to record the IP Address and port number of the sender. 
            // The IPEndPoint will allow you to read datagrams sent from any source.
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            string returnData = null;
            try
            {

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);

                returnData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine("This is the message you received " +
                                             returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                            RemoteIpEndPoint.Address.ToString() +
                                            " on their port number " +
                                            RemoteIpEndPoint.Port.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("BBJKBJKB" + e.ToString());
                
            }

            List<string> infoList = new List<string>();
            infoList.Add(RemoteIpEndPoint.Address.ToString());
            infoList.Add(RemoteIpEndPoint.Port.ToString());
            infoList.Add(returnData);
            return infoList;
        }
    }
}
