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
        private int blobMin = 100;
        private int blobMax = 400;

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
            ArrayList cornerPoints = new ArrayList();
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
                cornerPoints.Add(corners);
            }
            return cornerPoints;
        }
    }
}
