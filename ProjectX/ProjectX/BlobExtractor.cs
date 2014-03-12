using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging;
using AForge.Math;


namespace ProjectX
{
    public class BlobExtractor
    {
        BlobCounter extractor;

        public BlobExtractor ()
        {
            iniExtractor();
        }

        private void iniExtractor()
        {
            extractor = new BlobCounter();
            extractor.FilterBlobs = true;
            extractor.MinWidth = extractor.MinHeight = 150;
            extractor.MaxWidth = extractor.MaxHeight = 350;
        }

        public void setMinimum(int minimum)
        {
            extractor.MinWidth = extractor.MinHeight = minimum;
        }

        public void setMaximum(int maximum)
        {
            extractor.MaxWidth = extractor.MaxHeight = maximum;
        }

        public List<IntPoints> extractBlobs (Bitmap image) 
        {
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {

            }
        }
    }
}
