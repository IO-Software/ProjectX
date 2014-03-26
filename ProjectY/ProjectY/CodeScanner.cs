using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectY
{
    class CodeScanner
    {
        private Bitmap streamImage;
        Boolean rotate;
        int amountOfRotation;
        private int imageHeight;

        public CodeScanner()
        {

        }

        public string scan(Bitmap stream)
        {
            this.streamImage = stream;
            imageHeight = stream.Height;
            String code = null;
            amountOfRotation = 0;
            rotate = false;
            if (determineQR())
            {
                ArrayList qrCode = determineCode();
                if (rotate)
                {
                    
                    qrCode = rotateQR(qrCode);
                }
                code = Codes.getCode(qrCode);
            }
            return code;
        }

        private ArrayList rotateQR(ArrayList qrCode)
        {
            for (int i = 0; i < amountOfRotation; i++)
            {
                int temp = (int)qrCode[2];
                qrCode[2] = qrCode[1];
                qrCode[1] = qrCode[0];
                qrCode[0] = qrCode[3];
                qrCode[3] = temp;     
            }
            String temp2 = "";
            for (int i = 0; i < 4; i++)
            {
                temp2 = temp2 + qrCode[i] + ";";
            }
            return qrCode;
        }

        private Boolean determineQR()
        {
            ArrayList arrayQR = new ArrayList();
            arrayQR.Add(determineColor((int)(imageHeight / 12) * 2, (int)(imageHeight / 12) * 2));
            arrayQR.Add(determineColor((int)(imageHeight / 12) * 10, (int)(imageHeight / 12) * 2));
            arrayQR.Add(determineColor((int)(imageHeight / 12) * 2, (int)(imageHeight / 12) * 10));
            arrayQR.Add(determineColor((int)(imageHeight / 12) * 10, (int)(imageHeight / 12) * 10));
            arrayQR.Add(determineColor((int)(imageHeight / 12) * 6, (int)(imageHeight / 12) * 6));

            // Wanneer er één van de zwarte vlakken niet duidelijk is (oftwel, 2)
            for (int i = 0; i < arrayQR.Count; i++)
            {
                if ((int)arrayQR[i] == 2)
                {
                    Console.WriteLine("invalid operation: er zit een #2 in");
                    return false;
                }
            }

            // Wanneer de middelste niet zwart is return false
            if ((int)arrayQR[4] == 0)
            {
                Console.WriteLine("invalid operation: #4 == 0");
                return false;
            }

            // Wanneer er geen drie zwarte vlakjes zijn return false
            if (!threeBlackSquares(arrayQR))
            {
                Console.WriteLine("invalid operation: black #<3");
                return false;
            }

            determineRotation(arrayQR);
            return true;
        }

        private void determineRotation(ArrayList arrayQR)
        {
            if ((int)arrayQR[2] == 0)
            {
                rotate = true;
                amountOfRotation = 1;
            }
            else if ((int)arrayQR[1] == 0)
            {
                rotate = true;
                amountOfRotation = 3;
            }
            else if ((int)arrayQR[0] == 0)
            {
                rotate = true;
                amountOfRotation = 2;
            }
        }

        private Boolean threeBlackSquares(ArrayList arrayQR)
        {
            int amountBlackSquares = 0;
            for (int i = 0; i < arrayQR.Count - 1; i++)
            {
                if ((int)arrayQR[i] == 1)
                {
                    amountBlackSquares += 1;
                }
            }
            if (amountBlackSquares == 3)
            {
                return true;
            }
            return false;
        }

        private ArrayList determineCode()
        {
            ArrayList arrayCode = new ArrayList();
            arrayCode.Add(determineColor((int)(imageHeight / 12) * 6, (int)(imageHeight / 12) * 4));
            arrayCode.Add(determineColor((int)(imageHeight / 12) * 8, (int)(imageHeight / 12) * 6));
            arrayCode.Add(determineColor((int)(imageHeight / 12) * 6, (int)(imageHeight / 12) * 8));
            arrayCode.Add(determineColor((int)(imageHeight / 12) * 4, (int)(imageHeight / 12) * 6));
            return arrayCode;
        }

        private int determineColor(int x, int y)
        {
            int colorValue = 0;
            try
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        Color pixelColor = streamImage.GetPixel(x + i, y + j);
                        if (pixelColor.R > 175 && pixelColor.G > 175 && pixelColor.B > 175)
                        {
                            colorValue = colorValue - 1;
                        }
                        else
                        {
                            colorValue = colorValue + 1;
                        }
                    }
                }
            }
            catch (InvalidOperationException e) 
            {
                Console.WriteLine("Fout opgetreden bij het lezen van de pixels. Niet enorm erg, lost zichzelf op");
                Console.WriteLine(e.StackTrace);
            }
            if (colorValue > 0)
            {
                return 1;
            }
            else if (colorValue < 0)
            {
                return 0;
            }
            else
            {
                Console.WriteLine("INVALID WAARDE");
                return 2;
            }
        }
    }
}
