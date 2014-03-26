using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ProjectY
{
    public class Codes
    {
        private StreamReader reader;
        private Assembly assembly;
        private static ArrayList QRCodes = new ArrayList();
        private static ArrayList QRCodesNames = new ArrayList();

        public Codes()
        {
            assembly = Assembly.GetExecutingAssembly();
            loadCodes();
        }

        private void loadCodes()
        {
            readCode("player1");
            readCode("player2");
            readCode("wall");
        }

        public static string getCode(ArrayList qrBits)
        {
            for (int i = 0; i < QRCodes.Count; i++)
            {
                Boolean compare = true;
                if (qrBits.Count == 4)
                {
                    ArrayList singleLoadedQRCode = (ArrayList)QRCodes[i];
                    for (int j = 0; j < qrBits.Count; j++)
                    {
                        int qrBitsJ = Convert.ToInt32(qrBits[j]);
                        int singleLoadedQRCodeJ = Convert.ToInt32(singleLoadedQRCode[j]);
                        if (qrBitsJ != singleLoadedQRCodeJ)
                        {
                            compare = false;
                        }
                    }
                    if (compare)
                    {
                        Console.WriteLine("NAAM VAN OBJECT: " + (String)QRCodesNames[i]);
                        return (String) QRCodesNames[i];
                    }
                }
            }
            Console.WriteLine("Geen code herkend");
            return null;
        }

        public void readCode(String fileName)
        {
            try
            {
                ArrayList code = new ArrayList();
                reader = new StreamReader(assembly.GetManifestResourceStream("ProjectY.QRCodes." + fileName + ".txt"));
                String name = reader.ReadLine();
                String line = reader.ReadLine();
                while (line != null)
                {
                    code.Add(line);
                    line = reader.ReadLine();
                }
                if (code.Count == 4)
                {
                    QRCodes.Add(code);
                    QRCodesNames.Add(name);
                    Console.WriteLine(fileName + " has been added to QR Codes");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("FOUT in reader: " + e.StackTrace);
                Console.WriteLine("Dit betreft de file: " + fileName);
            }
        }
    }
}
