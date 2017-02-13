using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ImageDisplayClient
{
    public static class Global
    {
        public static string captureCount = "";
        public static string cameraNumber = "";
        public static string projectorNumber = "";
        public static Manager value;
        public static Form1 mainForm;
        public static Camera cam;
        public static bool mainFormLoaded = false;
        public static string sessionID = "1234";
        public static string pathName = null;
        public static string myCameraNumber = "";  //This is the camera order.
        public static string myProjNumber = "";  //This is the proj attached to the camera.
        public static bool closing = false;
        public static string xRes = "";
        public static string yRes = "";
        public static List<Bitmap> ListOfImg = new List<Bitmap>();
        public static List<string> ListOfBase64Img = new List<string>();
        public static TCPConnection tcpc;
        public static string startPath;
        public static string zipPath;
        public static void SetForm(Form1 p_form)
        {
            mainForm = p_form;
            mainFormLoaded = true;
        }

        public static void SetCamera()
        {
            cam = new Camera();
            cam.Start();
        }

        public static void CaptureWithImageChange(string index)
        {

        }

        public static int GetStartXPosition()
        {
            double t = Convert.ToInt32(xRes) * 0.26;
            return (int)t;
        }

        public static int GetStartYPosition()
        {
            double t = Convert.ToInt32(yRes) * 0.3;
            return (int)t;
        }

        public static int GetYLengthPosition()
        {
            double t = Convert.ToInt32(yRes) * 0.3;
            return (int)t;
        }

        public static int GetXLengthPosition()
        {
            double t = Convert.ToInt32(xRes) * 0.4166666666;
            return (int)t;
        }

        public static void SetExp(string p_value)
        {
            string[] temp = p_value.Split(',');
            cam.SetExp(temp[1]);
        }

        public static void SetPN(string p_value)
        {
            string[] temp = p_value.Split(',');
            projectorNumber = temp[1];
        }

        public static void SetCC(string p_value)
        {
            string[] temp = p_value.Split(',');
            captureCount = temp[1];
        }

        public static void SetCopy(string p_value)
        {
            startPath = @"c:\summit\calibration\"+sessionID;
            zipPath = @"c:\summit\calibration\"+sessionID+".zip";
            //string extractPath = @"c:\example\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            //ZipFile.ExtractToDirectory(zipPath, extractPath);

            //string[] temp = p_value.Split(',');
            //captureCount = temp[1];
            //Copy the files to a designated location.
            //Encode each item in the Global image list as base 64 and send to server.
            //foreach ( Bitmap b in ListOfImg)
            //{
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    byte[] byteImage = ms.ToArray();
            //    string base64String = Convert.ToBase64String(byteImage);
            //    ListOfBase64Img.Add(base64String);
            //    tcpc.Send("IMG,base64String);
            //}

            //byte[] zipfile = System.Text.Encoding.UTF8.GetBytes(System.Convert.ToBase64String(System.IO.File.ReadAllBytes(zipPath)));
            //tcpc.Send("ZIP," + System.Convert.ToBase64String(System.IO.File.ReadAllBytes(zipPath)));

           // byte[] zipfile = System.Text.Encoding.UTF8.GetBytes(System.Convert.ToBase64String(System.IO.File.ReadAllBytes(zipPath)));
           // string test = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(zipPath));
            tcpc.Send("ZIP," + System.Convert.ToBase64String(System.IO.File.ReadAllBytes(zipPath)));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static void ClearImages()
        {

        }

        public static void ChangeImage(string index)
        {
            Global.mainForm.ShowImage(index);
        }

        public static void Capture()
        {
            cam.CaptureFrame();
        }

        internal static void SetBrightness(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSB(temp[1]);
        }

        internal static void SetContrast(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSC(temp[1]);
        }

        internal static void SetGain(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSG(temp[1]);
        }

        internal static void SetGamma(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSGAM(temp[1]);
        }

        internal static void SetSat(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSS(temp[1]);
        }

        internal static void SetSharp(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSSHARP(temp[1]);
        }

        internal static void SetHue(string data)
        {
            string[] temp = data.Split(',');
            cam.SetSH(temp[1]);
        }

        internal static void SetWB(string data)
        {
            throw new NotImplementedException();
        }
    }
}
