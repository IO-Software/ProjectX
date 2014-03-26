using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;

namespace ProjectY
{
    public partial class Window : Form
    {
        private FilterInfoCollection videoDevices;
        private Webcam webcam;

        public Window()
        {
            InitializeComponent();
            InitializeWebcams();
        }

        private void InitializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cboxWebcams.Items.Add(Device.Name);
            }
            cboxWebcams.SelectedIndex = 0;
            webcam = new Webcam(pboxStream);
            webcam.testing(pboxTest);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            webcam.setVideoSource(videoDevices[cboxWebcams.SelectedIndex].MonikerString);
            if (webcam.isRunning())
            {
                webcam.stop();
                webcam.clearPictureBoxes();
            }
            else
            {
                webcam.turnOn();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
            }
        }
    }
}
