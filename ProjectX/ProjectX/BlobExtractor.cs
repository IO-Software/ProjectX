using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using AForge.Imaging;
using AForge;
using AForge.Math;
using AForge.Math.Geometry;


namespace ProjectX
{
    public class BlobExtractor
    {
        BlobCounter extractor;
        private Pen pen = new Pen(Color.Red, 2);

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

        public Bitmap extractBlobs (Bitmap image) 
        {
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

                using (var draw = Graphics.FromImage(image))
                {
                    if (corners.Count = 4)
                    {
                        for 
                    }
                }
                
            }

        }
    }
}
