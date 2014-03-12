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
        private BlobCounter extractor;

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

        // DEZE KLASSE MOET ALLEEN EEN INTPOINT LIJST TERUG STUREN. ZO KAN ER GETEKEND WORDEN OP HET PLAATJE
        // IN DE WEBCAMCLASS EN ZO KAN HET ORGINELE BEELD BEHOUDEN BLIJVEN.
        // ER MOET ECHTER NOG WEL WAT WORDEN GEVONDEN WORDEN VOOR DE FOREACH BLOB. DIT GAAT NATUURLIJK NIET 
        // GOED WANNEER IK DIT TERUGGEEF --> EEN LIJST MET 4 x INTPOINT? (GAAT DIT NIET HAKKEN IN DE SNELHEID?)
        public Bitmap extractBlobs (Bitmap image) 
        {
            extractor.ProcessImage(image);
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
            }
            return image;
        }
    }
}
