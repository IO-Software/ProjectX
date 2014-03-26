using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using AForge.Imaging;
using AForge;
using AForge.Math.Geometry;

namespace ProjectY
{
    class BlobExtractor
    {
        private BlobCounter extractor;
        private int blobMin = 18;
        private int blobMax = 80;
        private int imageWidth;
        private int imageHeight;
        private Boolean widthHeightCheck = false;

        public BlobExtractor()
        {
            InitializeExtractor();
        }

        private void InitializeExtractor()
        {
            extractor = new BlobCounter();
            extractor.FilterBlobs = true;
            extractor.MinWidth = extractor.MinHeight = blobMin;
            extractor.MaxWidth = extractor.MaxHeight = blobMax;
        }

        public ArrayList extractBlob(Bitmap image)
        {
            if (!widthHeightCheck)
            {
                this.imageHeight = image.Height;
                this.imageWidth = image.Width;
                widthHeightCheck = true;
            }
            ArrayList cornerPoints = new ArrayList();
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
                Boolean boundaryCheck = true;
                if (corners.Count == 4)
                {
                    for (int i = 0; i < corners.Count; i++)
                    {
                        if (!withinBoundary(corners[i].X, corners[i].Y))
                        {
                            boundaryCheck = false;
                        }
                    }
                    if (boundaryCheck)
                    {
                        cornerPoints.Add(corners);
                    }
                }
            }
            Console.WriteLine("AANTAL HERKENDE OBJECTEN: " + cornerPoints.Count);
            return cornerPoints;
        }

        private Boolean withinBoundary(int x, int y)
        {
            if (y < -2.625 * x + 240 || y < 2.625 * x - 1440)
            {
                return false;
            }
            return true;
        }
    }
}
