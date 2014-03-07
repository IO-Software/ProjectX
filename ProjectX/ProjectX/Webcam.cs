using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video.DirectShow;
using AForge.Video;

namespace ProjectX
{
    class Webcam
    {
        private VideoCaptureDevice videoSource;
        private String videoSourceString;
        private PictureBox pBoxUp;
        private PictureBox pBoxDown;

        public Webcam()
        {
            videoSource = new VideoCaptureDevice();
        }

        public void setVideoSource(String source)
        {
            videoSourceString = source;
        }

        public Boolean isRunning()
        {
            return videoSource.IsRunning;
        }

        public void stop()
        {
            // Stop streaming
            videoSource.Stop(); 
        }

        public void turnOn(PictureBox tempPicBoxUp, PictureBox tempPicBoxDown)
        {
            pBoxUp = tempPicBoxUp;
            pBoxDown = tempPicBoxDown;
            videoSource = new VideoCaptureDevice(videoSourceString);
            // De Videokaart
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
            Console.WriteLine("write");
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap original = (Bitmap)eventArgs.Frame.Clone();
            Bitmap trial = (Bitmap)eventArgs.Frame.Clone();
            pBoxUp.Image = original;
            trial = null;
            pBoxDown.Image = trial;
        }
    }
}
