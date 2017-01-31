using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDisplayClient
{
    public class Manager
    {
        public Form1 mainForm;
        public Manager()
        {
            
        }

        public void CreateDir(string p_sessionID)
        {
            // Specify the directory you want to manipulate.
            string path = @"c:\summit\"+p_sessionID;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    // Try to create the directory.
                    DirectoryInfo di = new DirectoryInfo(path);
                    di.Delete(true);
                    Console.WriteLine("The directory was deleted successfully.");
                    Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                    // Delete the directory.

                    Global.pathName = path + "\\";
                    return;
                }

                DirectoryInfo did = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                Global.pathName = path + "\\";
                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        public void ReadConfigFile()
        {
            string path = @"c:\summit\imagerconfig.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("No Config file found in C:\\summit");
                Global.mainForm.Close();
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Read from config file: " + s);
                    Global.myCameraNumber = s;
                }
                
            }
            
            
        }

        public void Start()
        {
            while(true)
            {
                if (!Global.mainFormLoaded)
                {
                    Thread.Sleep(50);
                }
                else
                    break;
            }

            //Read Config file.
            //Let Server know which order this client is:
            ReadConfigFile();

            Global.SetCamera();
            mainForm = Global.mainForm;
            //mainForm.ShowImage("2");
            //Wait for UDP broadcast

            UDPConnection udpc = new UDPConnection(49455);
            List<string> res = udpc.StartListening();

            string[] t_temp = res.ElementAt(2).Split(',');
            Global.sessionID = t_temp[1];
            CreateDir(t_temp[1]);
            TCPConnection tcpc = new TCPConnection(res.ElementAt(0), t_temp[0]);
            tcpc.Connect();

            
            //res index 0 is ip address, index 1 is port that the server sent on, index 2 is the message aka port of the server to connect to.

            //Make tcp connection to the server

            //Get the session id

            //Init camera


            //Wait for server to issue capture commands
            

            //Wait for all clear command

            //quit.
        }
    }
}
