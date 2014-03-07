using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging.Filters;

namespace ProjectX
{
    class Filters
    {
        private FiltersSequence otsu;

        public Filters()
        {
            iniOtsu();
        }

        private void iniOtsu()
        {
            otsu = new FiltersSequence();
            // Add a grayscale filter to get out all the colors
            otsu.Add(Grayscale.CommonAlgorithms.BT709);
            // Converts the image into a binary black and white image with the otsu algorithm
            otsu.Add(new OtsuThreshold());
        }

        static Bitmap executeOtsu(Bitmap image)
        {
            return image;
        }
    }
}
