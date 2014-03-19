using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using ZXing.QrCode;
using ZXing.Common;
using ZXing;

namespace ProjectX
{
    class QR_Reader
    {
        private String testCode = "C:/Users/Huib/Documents/IO/Keuzevak Software/sample.png";
        private QRCodeReader reader = new QRCodeReader();
        public QR_Reader()
        {

        }
        // Source: http://www.codeproject.com/Questions/441372/zxing-QRCode-Encoding-and-Decoding-in-csharp
        private String qrReader(Bitmap image)
        {
            byte[] byteImage = ImageToByte(image);
            try
            {
                ZXing.LuminanceSource source = new ZXing.RGBLuminanceSource(byteImage, image.Width, image.Height);
                var binarizer = new HybridBinarizer(source);
                var binBitmap = new BinaryBitmap(binarizer);
                return reader.decode(binBitmap).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
