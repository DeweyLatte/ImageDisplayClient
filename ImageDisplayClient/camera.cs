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
        public Camera()
        {

        }

        public void Start()
        {
            ImageViewer viewer = new ImageViewer(); //create an image viewer
            capture = new VideoCapture(0); //create a camera captue
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Exposure, -1); //-13 to -1
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 30);  //15
            //capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Brightness, 30);  //-64 - 64
            // capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Gain, 10);  //0 - 64
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 3264);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 2448);
            Thread.Sleep(1000);
            //Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            //{  //run this until application closed (close button click on image viewer)
            //    capture.Grab();
            //});

            //capture.ImageGrabbed += new EventHandler(delegate (object sender, EventArgs e)
            //{  //run this until application closed (close button click on image viewer)
            //    Image<Bgr, Byte> imageInvert = new Image<Bgr, Byte>(640, 480);
            //    capture.Retrieve(imageInvert); //draw the image obtained from camera
            //    viewer.Image = imageInvert;
            //});

            //viewer.Show(); //show the image viewer
        }

        public string GenerateName()
        {
            string fn = Global.pathName;
            fn += Global.cameraNumber;
            fn += "-";
            fn += Global.captureCount;
            fn += ".png";
            return fn;
        }

        public void CaptureFrame()
        {
            Mat res = null;
            for (int i = 0; i < 3; i ++)
            {
                res = capture.QueryFrame();
            }
            string name = GenerateName();
            res.Save(@name);
            //saveJpeg("C:\\test.jpg", res.Bitmap, 100);
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
