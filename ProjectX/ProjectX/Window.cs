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

namespace ProjectX
{
    public partial class Window : Form
    {
        private float maxScreenWidth;
        private float maxScreenHeight;
        private FilterInfoCollection videoDevices;
        private Webcam webcam;
        private Filters camFilter;

        private const int caseGreyscale = 0;
        private const int caseOtsu = 1;
        private const int caseDraw2D = 2;
        private const int caseDraw3D = 3;

        private int trackMinValue = 0;
        private int trackMaxValue = 500;

        /// <summary>
        /// The class window provides the interface of the program. This class also initializes the webcam for the pictureboxes. 
        /// </summary>
        public Window()
        {
            // The maximal screensizes (NOT USED)
            maxScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            maxScreenWidth = Screen.PrimaryScreen.Bounds.Width;

            InitializeComponent();
            // Initializes the filter for card recognition
            initializeFilters();
            // Initializes the webcam for card recognition
            initializeWebcams();
        }

        /// <summary>
        /// This method looks through all the available webcam options and adds them to the combobox. It also creates a new webcam and provides the 
        /// webcam with pictureboxes where it can show the image
        /// </summary>
        private void initializeWebcams()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in videoDevices)
            {
                cBoxCam.Items.Add(Device.Name);
            }
            cBoxCam.SelectedIndex = 0;
            webcam = new Webcam(pBoxOriginal, pBoxAltered, camFilter, tbMinValueEx.Value, tbMaxValueEx.Value);
        }

        private void initializeFilters()
        {
            camFilter = new Filters();
        }

        /// <summary>
        /// When the button on/off has been pushed it checks if the webcam is on or off. If the webcam is on it will stop the current feed of the webcam
        /// and clears both pictureboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnOff_Click(object sender, EventArgs e)
        {
            webcam.setVideoSource(videoDevices[cBoxCam.SelectedIndex].MonikerString);
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

        /// <summary>
        /// When the button Quit has been pushed it checks if the webcam is running. If so, it will close the webcamfeed and shuts it down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// When the form is closed this method checks if the webcam is running. If so, it will close the webcamfeed and shuts it down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
            }
        }

        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxChoice.SelectedIndex)
            {
                case caseGreyscale:
                    webcam.setGrayFilter(true);
                    webcam.setOtsuFilter(false);
                    webcam.blobExtractor.setDraw2D(false);
                    webcam.blobExtractor.setDraw3D(false);
                    webcam.setDrawBlobs(false);
                    break;
                case caseOtsu:
                    webcam.setGrayFilter(false);
                    webcam.setOtsuFilter(true);
                    webcam.blobExtractor.setDraw2D(false);
                    webcam.blobExtractor.setDraw3D(false);
                    webcam.setDrawBlobs(false);
                    break;
                case caseDraw2D:
                    webcam.setGrayFilter(false);
                    webcam.setOtsuFilter(true);
                    webcam.blobExtractor.setDraw2D(true);
                    webcam.blobExtractor.setDraw3D(false);
                    webcam.setDrawBlobs(true);
                    break;
                case caseDraw3D:
                    webcam.setGrayFilter(false);
                    webcam.setOtsuFilter(true);
                    webcam.blobExtractor.setDraw2D(true);
                    webcam.blobExtractor.setDraw3D(true);
                    webcam.setDrawBlobs(true);
                    break; 
            }
        }

        private void tbMinValueEx_Scroll(object sender, EventArgs e)
        {
            
            if (tbMinValueEx.Value + 2 > tbMaxValueEx.Value)
            {
                tbMaxValueEx.Value = tbMinValueEx.Value + 1;
            }
            lblMinValueEx.Text = "Minimum value extractor: " + tbMinValueEx.Value;
            lblMaxValueEx.Text = "Maximum value extractor: " + tbMaxValueEx.Value;
            webcam.blobExtractor.setMinimum(tbMinValueEx.Value);
        }

        private void tbMaxValueEx_Scroll(object sender, EventArgs e)
        {
            if (tbMaxValueEx.Value - 2 < tbMinValueEx.Value)
            {
                tbMinValueEx.Value = tbMaxValueEx.Value - 1;
            }
            lblMinValueEx.Text = "Minimum value extractor: " + tbMinValueEx.Value;
            lblMaxValueEx.Text = "Maximum value extractor: " + tbMaxValueEx.Value;
            webcam.blobExtractor.setMaximum(tbMaxValueEx.Value);
        }
    }
}
