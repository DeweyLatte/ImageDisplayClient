using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDisplayClient
{
    public class TCPConnection
    {
        private int port;
        private string serverIP;
        private TcpClient tcpclient;

        public TCPConnection(string p_serverIP, string p_serverPort)
        {
            serverIP = p_serverIP;
            port = Convert.ToInt32(p_serverPort);
        }

        public void Start()
        {

        }

        public void Listen()
        {
            TcpListener server = null;
            try
            {
                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Connected!");
                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = tcpclient.GetStream();
                    
                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        data = data.Substring(1);
                        if(data == "1" || data == "2" || data == "3" || data == "4" || data == "5" || data == "6" || data == "7" || data == "8" || data == "9" || data == "10" || data == "11" || data == "12" || data == "black"
                            || data == "white" || data == "gray")
                        {
                            Thread tt = new Thread(() => Global.ChangeImage(data));
                            tt.Start();
                        }
                        else if(data.Contains("capture"))
                        {
                            Thread tc = new Thread(() => Global.Capture());
                            tc.Start();
                        }
                        else if(data.Contains("SE"))  //Set Exposure Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetExp(data));
                            ts.Start();
                        }
                        else if (data.Contains("SB"))  //Set Brightness Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetBrightness(data));
                            ts.Start();
                        }
                        else if (data.Contains("SC"))  //Set Contrast Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetContrast(data));
                            ts.Start();
                        }
                        else if (data.Contains("SG"))  //Set Gain Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetGain(data));
                            ts.Start();
                        }
                        else if (data.Contains("SGAM"))  //Set Gamma Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetGamma(data));
                            ts.Start();
                        }
                        else if (data.Contains("SS"))  //Set Saturation Level
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetSat(data));
                            ts.Start();
                        }
                        else if (data.Contains("SSHARP"))  //Set Sharpness Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetSharp(data));
                            ts.Start();
                        }
                        else if (data.Contains("SH"))  //Set HUE Level.
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetHue(data));
                            ts.Start();
                        }
                        else if (data.Contains("SWB"))  //Set WhiteBalance
                        {
                            //exposure
                            Thread ts = new Thread(() => Global.SetWB(data));
                            ts.Start();
                        }
                        else if (data.Contains("PN")) // Projector Number
                        {
                            //camera number
                            Thread tpn = new Thread(() => Global.SetPN(data));
                            tpn.Start();
                        }
                        else if (data.Contains("CC"))  //Capture Count
                        {
                            //capturecount
                            Thread tcc = new Thread(() => Global.SetCC(data));
                            tcc.Start();
                        }
                        else if (data.Contains("COPY"))  //Copy data to the main client
                        {
                            Thread tcopy = new Thread(() => Global.SetCopy(data));
                            tcopy.Start();
                        }
                        Thread.Sleep(10);
                    }

                    // Shutdown and end connection
                    tcpclient.Close();
                    Global.closing = true;
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    Global.mainForm.Close(); //to turn off current app
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                //server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public void Send(string p_msg)
        {
            int b = (int)p_msg.Length;

            byte[] intBytes = BitConverter.GetBytes(b);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;

            string t = "";
            t += "AAAA";
            //t += result[1];
            //t += result[2];
            //t += result[3];
            t += p_msg;
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(t);
            data[0] = result[0];
            data[1] = result[1];
            data[2] = result[2];
            data[3] = result[3];

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();


            NetworkStream stream = tcpclient.GetStream();
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
            
            Console.WriteLine("Sent: {0}", t);

            // Receive the TcpServer.response.


        }

        public void Connect()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.

                tcpclient = new TcpClient(serverIP, port);
               
                Task t = new Task(Listen);
                t.Start();
                Thread.Sleep(2000);
                Send("MCN," + Global.myCameraNumber);
                //for(int i = 0; i < 100; i++)
                {
                    //Send("MCN," + Global.myCameraNumber + char.MinValue);
                    //Thread.Sleep(2000);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }
    }
}
