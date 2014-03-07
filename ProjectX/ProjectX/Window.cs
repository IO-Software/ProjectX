using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;

namespace ProjectX
{
    public partial class Window : Form
    {
        private float maxScreenWidth;
        private float maxScreenHeight;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        
        public Window()
        {
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            
            InitializeComponent(maxScreenWidth, maxScreenHeight);
            loadWebcams();
        }

        private void loadWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
        }

        private void btnOnOff_Click(object sender, EventArgs e) 
        {
            if (videoSource.IsRunning) //Als camera aanstaan
            {
                videoSource.Stop(); //Stop streamen
                pBoxUp.Image = null; //Verwijderd het image uit het geheugen van picturebox
                pBoxUp.Invalidate(); //Refreshed de picturebox
                pBoxDown.Image = null;
                pBoxDown.Invalidate();
            }
            else //Als de camera nog niet aan staat
            {
                videoSource = new VideoCaptureDevice(videoDevices[cBoxCam.SelectedIndex].MonikerString);
                // De Videokaart
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }
        }

        private void btnQuit_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image2 = (Bitmap)eventArgs.Frame.Clone();
            pBoxDown.Image = image2;
            pBoxUp.Image = image;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
    }
}
