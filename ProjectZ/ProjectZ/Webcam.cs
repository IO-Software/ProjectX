using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

using AForge;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Imaging.Filters;
using System.Diagnostics;

namespace ProjectZ
{
    class Webcam
    {
        private String videoSourceString;
        private VideoCaptureDevice videoSource;
        private Bitmap stream;

        private int streamWidth;
        private int streamHeight;

        public Webcam() 
        {
            videoSource = new VideoCaptureDevice();
        }

        public void setVideoSource(String source)
        {
            videoSourceString = source;
        }

        public Boolean hasVideoSource()
        {
            if (videoSourceString != null)
            {
                return true;
            }
            return false;
        }

        public Boolean isRunning()
        {
            return videoSource.IsRunning;
        }

        public void stop()
        {
            videoSource.Stop();
        }

        public void turnOn()
        {
            videoSource = new VideoCaptureDevice(videoSourceString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            stream = new Bitmap((Bitmap)eventArgs.Frame.Clone());
            streamWidth = stream.Width;
            streamHeight = stream.Height;
            stream.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        public Bitmap getStreamImage()
        {
            return stream;
        }

        public int getHeight()
        {
            if (streamHeight > 0)
            {
                return streamHeight;
            }
            return 0;
        }

        public int getWidth()
        {
            if (streamWidth > 0)
            {
                return streamWidth;
            }
            return 0;
        }
    }
}
