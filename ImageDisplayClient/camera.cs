using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace ImageDisplayClient
{
    public class Camera
    {
        VideoCapture capture;
        Image<Bgr,byte> resImg = null;
        Mutex img = new Mutex();
        public Camera()
        {

        }

        public void Start()
        {
            ImageViewer viewer = new ImageViewer(); //create an image viewer
            capture = new VideoCapture(); //create a camera captue
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.AutoExposure, 0);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -1); //-13 to -1
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 30);  //15
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness, 30);  //-64 - 64
            // capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain, 10);  //0 - 64
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 2592);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 1944);

            
            Thread tt = new Thread(() => InitCamera());
            tt.Start();

            
            //Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            //{  //run this until application closed (close button click on image viewer)
            //    capture.Grab();
            //});

            capture.ImageGrabbed += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
                img.WaitOne();
                Image<Bgr, Byte> imageInvert = new Image<Bgr, Byte>(2592, 1944);
                capture.Retrieve(imageInvert); //draw the image obtained from camera
                //viewer.Image = imageInvert;
                resImg = imageInvert;
                img.ReleaseMutex();
            });

            Thread ttt = new Thread(() => {
                while(true)
                {
                    if (Global.closing)
                        break;
                    capture.Grab();
                    Thread.Sleep(100);
                }
                });
            ttt.Start();

            //viewer.Show(); //show the image viewer
        }

        private void InitCamera()
        {
            Thread.Sleep(3000);
            for (int i = 0; i < 1; i++)
            {
                capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.AutoExposure, 0);
                capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -1); //-13 to -1
                Mat tep = capture.QueryFrame();
                capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.AutoExposure, 0);
                capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -1); //-13 to -1
            }
        }

        public string GenerateName()
        {
            string fn = Global.pathName;
            fn += "IM_";
            fn += Global.myCameraNumber;
            fn += "_";
            fn += Global.projectorNumber;
            fn += "_";
            fn += Global.captureCount;
            fn += ".jpg";
            return fn;
        }

        public void CaptureFrame()
        {
            Console.WriteLine("Capturing");
            //Mat res = null;
            //for (int i = 0; i < 3; i ++)
            //{
            //    res = capture.QueryFrame();
            //}
            string name = GenerateName();
            img.WaitOne();
            saveJpeg(@name, resImg.Bitmap, 80);
            //Save to array.
            Global.ListOfImg.Add(resImg.Bitmap);
            img.ReleaseMutex();
            //res.Save(@name);
            //saveJpeg(@name, res.Bitmap, 80);
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality

            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        public void SetExp(string p_val)
        {
            Console.WriteLine("Set exp " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSB(string p_val)
        {
            Console.WriteLine("Set brigtness " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSC(string p_val)
        {
            Console.WriteLine("Set contrast " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Contrast, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSG(string p_val)
        {
            Console.WriteLine("Set gain " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSGAM(string p_val)
        {
            Console.WriteLine("Set gamma " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gamma, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSS(string p_val)
        {
            Console.WriteLine("Set saturation " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Staturation, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSSHARP(string p_val)
        {
            Console.WriteLine("Set sharpness " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Sharpness, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSH(string p_val)
        {
            Console.WriteLine("Set hue " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Hue, Convert.ToInt32(p_val)); //-13 to -1
        }
        public void SetSWM(string p_val)
        {
            Console.WriteLine("Set exp " + p_val);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, Convert.ToInt32(p_val)); //-13 to -1
        }

        public void Grabbed()
        {

        }

        public void low()
        {

            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -12);
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 5);
        }

        public void high()
        {
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -1);
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 30);
        }
    }
}
