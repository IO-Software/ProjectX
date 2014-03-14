using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging.Filters;

namespace ProjectX
{
    /// <summary>
    /// This class provides the webcam with certain filters
    /// </summary>
    public class Filters
    {
        private FiltersSequence grayFilter;
        private FiltersSequence otsuFilter;

        private Boolean otsuOn;

        public Filters()
        {
            iniGrayFilter();
            iniOtsuFilter();
        }

        /// <summary>
        /// Initializes the grayscale filter
        /// </summary>
        private void iniGrayFilter()
        {
            grayFilter = new FiltersSequence();
            grayFilter.Add(Grayscale.CommonAlgorithms.BT709);
        }

        /// <summary>
        /// Initializes the otsu filter
        /// </summary>
        private void iniOtsuFilter()
        {
            otsuFilter = new FiltersSequence();
            otsuFilter.Add(Grayscale.CommonAlgorithms.BT709);
            otsuFilter.Add(new OtsuThreshold());
        }

        public Bitmap applyGreyFilter(Bitmap image)
        {       
            return grayFilter.Apply(image);
        }

        public Bitmap applyOtsuFilter(Bitmap image)
        {
            return otsuFilter.Apply(image);
        }
    }
}
