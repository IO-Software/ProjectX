using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY
{
    // Random class mag eigenlijk weg
    class RandomClass
    {
    }
}

//using AForge.Imaging.Filters;
//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProjectY
//{
//    // BRON: http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

//    class CodeScanner
//    {
//        private byte[] rgbValues;
//        private IntPtr ptr;
//        private int bytes;
//        private BitmapData cropData;

//        public CodeScanner()
//        {

//        }

//        public String scan(Bitmap image)
//        {
//            ArrayList croppedImages = convertToCroppedImages(image);
//            ArrayList arrayQRCode = lockAndReadBits(croppedImages);
//            int code = getCode(arrayQRCode);
//            unlockBits(image);
//            // AANPASSEN
//            return null;
//        }

//        private ArrayList convertToCroppedImages(Bitmap source)
//        {
//            ArrayList croppedImages = new ArrayList();
//            int length = source.Height;


//            // Deelt de bitman in 4 hoekpunten die gelezen wordt
//            Crop cropTopLeft = new Crop(new Rectangle(length / 10, length / 10, length / 5, length / 5));
//            Crop cropTopRight = new Crop(new Rectangle(length - length / 10 - length / 5, length / 10, length / 5, length / 5));
//            Crop cropBottomLeft = new Crop(new Rectangle(length / 10, length - length / 10 - length / 5, length / 5, length / 5));
//            Crop cropBottomRight = new Crop(new Rectangle(length - length / 10 - length / 5, length - length / 10 - length / 5, length / 5, length / 5));
//            Crop cropMiddle = new Crop(new Rectangle(length/2 - (length/5)/2, length/2 - (length/5)/2, length/5,length/5));

//            croppedImages.Add(cropTopLeft.Apply(source));
//            croppedImages.Add(cropTopRight.Apply(source));
//            croppedImages.Add(cropBottomLeft.Apply(source));
//            croppedImages.Add(cropBottomRight.Apply(source));
//            croppedImages.Add(cropMiddle.Apply(source));
//            return croppedImages;
//        }

//        private ArrayList lockAndReadBits(ArrayList croppedImages)
//        {
//            ArrayList arrayQRCode = new ArrayList();
//            foreach (Bitmap crop in croppedImages)
//            {
//                // Lock the bitmap bits
//                Rectangle rect = new Rectangle(0, 0, crop.Width, crop.Height);
//                cropData = crop.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, crop.PixelFormat);

//                // Get the address of the first line
//                ptr = cropData.Scan0;

//                // Declare an array to hold the bytes of the bitmap
//                bytes = Math.Abs(cropData.Stride) * crop.Height;
//                rgbValues = new byte[bytes];

//                // Copy the RGB values into the array
//                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

//                // Add the corresponding Colorvalue of the rgbvalue to the QRCode array
//                arrayQRCode.Add(determineColor(rgbValues));
//            }
//            return arrayQRCode;
//        }

//        private int determineColor(byte[] rgbValues)
//        {
//            int ValueBlack = 0;
//            int ValueWhite = 0;
//            for (int i = 0; i < bytes/3; i++)
//            {
//                // Per pixel zijn er 3 int waardes die interesssant zijn (i + (2*i) + 0, 1 of 2). De RGB waardes moeten nog worden getest.
//                int r = rgbValues[i + (2 * i)];
//                int g = rgbValues[i + (2 * i) + 1];
//                int b = rgbValues[i + (2 * i) + 2];

//                if (r > 200 && g > 200 && b > 200)
//                {
//                    ValueWhite += 1;
//                }
//                else if (r < 75 && g < 75 && b < 75)
//                {
//                    ValueBlack += 1;
//                }
//            }
//            if (ValueWhite > ValueBlack)
//            {
//                return 0;
//            }
//            else if (ValueBlack < ValueWhite) {
//                return 1;
//            }
//            else
//            {
//                return 2;
//            }
//        }

//        private int getCode(ArrayList arrayQRCode)
//        {
//            //return Codes.getCode(arrayQRCode);
//            return 0;
//        }

//        private void unlockBits(Bitmap image)
//        {
//            try
//            {
//                // Copy data from byte array to pointer
//                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);

//                // Unlock bitmap data
//                image.UnlockBits(cropData);
                
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
