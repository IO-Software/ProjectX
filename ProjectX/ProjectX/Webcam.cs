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
    public class Webcam
    {
        private VideoCaptureDevice videoSource;
        private String videoSourceString;
        private Filters camFilter;
        private BlobExtractor blobExtractor;
        private PictureBox pBoxOriginal;
        private PictureBox pBoxAltered;
        private Boolean extractorOn;

        /// <summary>
        /// Creates a new webcam with two pictureboxes where the webcam can show the feed.
        /// </summary>
        /// <param name="pBoxOr"></param>
        /// This picturebox will show the original webcamfeed
        /// <param name="pBoxTr"></param>
        /// This picturebox will show the altered webcamfeed
        public Webcam(PictureBox pBoxOriginal, PictureBox pBoxAltered)
        {
            this.pBoxOriginal = pBoxOriginal;
            this.pBoxAltered = pBoxAltered;
            videoSource = new VideoCaptureDevice();
            iniFilters();
            iniExtractor();
        }

        public void iniFilters()
        {
            camFilter = new Filters();
        }

        public void iniExtractor()
        {
            blobExtractor = new BlobExtractor();
        }

        /// <summary>
        /// Sets the video source of the webcam
        /// </summary>
        /// <param name="source"></param>
        /// A string with the location of the videosource. This string has been converted to a Monikerstring
        public void setVideoSource(String source)
        {
            videoSourceString = source;
        }

        /// <summary>
        /// Returns true when the webcam is running
        /// </summary>
        /// <returns>Returns true when the webcam is running</returns>
        public Boolean isRunning()
        {
            return videoSource.IsRunning;
        }

        /// <summary>
        /// Stops the webcam from running
        /// </summary>
        public void stop()
        {
            // Stop streaming
            videoSource.Stop(); 
        }

        /// <summary>
        /// Clears the pictureboxes given to the webcam
        /// </summary>
        public void clearPictureBoxes()
        {
            pBoxOriginal.Image = null;
            pBoxAltered.Image = null;
            pBoxOriginal.Invalidate();
            pBoxAltered.Invalidate();
        }

        /// <summary>
        /// Turns the webcam on
        /// </summary>
        public void turnOn()
        {
            videoSource = new VideoCaptureDevice(videoSourceString);
            // De Videokaart
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }

        /// <summary>
        /// Refreshes the image of the pictureboxes constantly. When filters have been turned on it will apply the filter onto the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap original = (Bitmap)eventArgs.Frame.Clone();
            Bitmap altered = (Bitmap)eventArgs.Frame.Clone();
            if (camFilter.getFilterStatus() != null)
            {
                altered = camFilter.applyFilter(altered);
            }
            pBoxOriginal.Image = original;
            pBoxAltered.Image = altered;
        }

        private void setGrayFilter(Boolean status)
        {
            if (camFilter != null)
            {
                camFilter.setGrayFilter(status);
            }
        }

        private void setOtsuFilter(Boolean status)
        {
            if (camFilter != null)
            {
                camFilter.setOtsuFilter(status);
            }
        }

        private void setExtractorMinimum(int minimum)
        {
            if (minimum > 0)
            {
                blobExtractor.setMinimum(minimum);
            }
        }

        private void setExtractorMaximum(int maximum)
        {
            if (maximum < int.MaxValue)
            {
                blobExtractor.setMaximum(maximum);
            }
        }
    }
}
