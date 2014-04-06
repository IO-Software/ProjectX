using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZ
{
    class Textures
    {
        private static List<Bitmap> textureList;
        private static List<String> textureNameList;

        private Assembly assembly;

        private static Bitmap defaultTexture;

        public Textures()
        {
            textureList = new List<Bitmap>();
            textureNameList = new List<String>();
            assembly = Assembly.GetExecutingAssembly();

            defaultTexture = loadTexture("default");
            addTextureToList(loadTexture("mainMenuBackground"), "mainMenuBackground");
            addTextureToList(loadTexture("firstIntroScreen"), "firstIntroScreen");
            addTextureToList(loadTexture("secondIntroScreen"), "secondIntroScreen");
            addTextureToList(loadTexture("thirdIntroScreen"), "thirdIntroScreen");
        }

        private Bitmap loadTexture(String fileName) 
        {
            Bitmap texture = null;
            try
            {
                texture = new Bitmap(assembly.GetManifestResourceStream("ProjectZ.Textures." + fileName + ".png"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Fout in het lezen van de nieuwe textures: " + e.StackTrace);
            }

            if (texture != null)
            {
                Console.WriteLine("Texture " + fileName + " ingeladen!");
                return texture;
            }
            else
            {
                Console.WriteLine("Texture is nog steeds null bij " + fileName + ", secondary test faal. Default texture ingezet");
                return defaultTexture;
            }
        }

        public static Bitmap getTexture(String textureName)
        {
            for (int i = 0; i < textureNameList.Count(); i++)
            {
                if (textureNameList[i].Equals(textureName))
                {
                    if (textureList[i] != null)
                    {
                        return textureList[i];
                    }
                }
            }
            return defaultTexture;
        }

        private void addTextureToList(Bitmap texture, String textureName)
        {
            if (texture != null && textureName != null)
            {
                textureList.Add(texture);
                textureNameList.Add(textureName);
            }
            else
            {
                Console.WriteLine("GEEN TEXTURE INGELADEN, TEXTURE OF TEXTURENAME IS NULL");
            }
        }
    }
}
