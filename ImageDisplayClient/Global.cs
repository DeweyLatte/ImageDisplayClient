using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDisplayClient
{
    public static class Global
    {
        public static string captureCount = "";
        public static string cameraNumber = "";
        public static Manager value;
        public static Form1 mainForm;
        public static Camera cam;
        public static bool mainFormLoaded = false;
        public static string sessionID = "1234";
        public static string pathName = null;
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

        public static void SetExp(string p_value)
        {
            string[] temp = p_value.Split(',');
            cam.SetExp(temp[1]);
        }

        public static void SetCN(string p_value)
        {
            string[] temp = p_value.Split(',');
            cameraNumber = temp[1];
        }

        public static void SetCC(string p_value)
        {
            string[] temp = p_value.Split(',');
            captureCount = temp[1];
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
    }
}
