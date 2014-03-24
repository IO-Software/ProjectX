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
        StreamReader reader;
        Assembly assembly;

        public Codes()
        {
            assembly = Assembly.GetExecutingAssembly();
            readCodes("cannon");
        }

        public static int getCode(ArrayList arrayQRCode)
        {
            return 0;
        }

        public void readCodes(String fileName)
        {
            try
            {
                reader = new StreamReader(assembly.GetManifestResourceStream("ProjectY.QRCodes." + fileName + ".txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("FOUT in reader: " + e.StackTrace);
            }
        }

        private void loadCodes()
        {

        }
    }
}
