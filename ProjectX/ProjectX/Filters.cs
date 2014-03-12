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
        private FiltersSequence filter;
        private FiltersSequence grayFilter;
        private FiltersSequence otsuFilter;
        private Boolean grayOn = false;
        private Boolean otsuOn = false;

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

        public Bitmap applyFilter(Bitmap image)
        {
            if (grayOn)
            {
                filter = grayFilter;
            }
            else if (otsuOn)
            {
                filter = otsuFilter;
            }
            else
            {
                filter = null;
            }
            return filter.Apply(image);
        }

        /// <summary>
        /// Sets the grayscale filter
        /// </summary>
        /// <param name="status">When true the grayscale will turn ON</param>
        public void setGrayFilter(Boolean status)
        {
            if (!status)
            {
                grayOn = false;
            }
            else
            {
                grayOn = true;
            }
        }

        /// <summary>
        /// Sets the otsu filter
        /// </summary>
        /// <param name="status">When true the grayscale will turn ON and the grayscalefilter will turn OFF</param>
        public void setOtsuFilter(Boolean status)
        {
            if (!status)
            {
                otsuOn = false;
            }
            else
            {
                grayOn = false;
                otsuOn = true;
            }
        }

        public FiltersSequence getFilterStatus()
        {
            return filter;
        }
    }
}
