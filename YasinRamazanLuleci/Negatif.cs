using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace YasinRamazanLuleci
{
    class Negatif : IImageDuzenleyici   //Imaji negatifine ceviren sinif
    {
        

        public void kaydet(string dosyaYolu)
        {
            string imageAdi = null;

            string[] Images = System.IO.Directory.GetFiles(dosyaYolu);

            foreach (string dosyalar in Images)
            {
                if (!Path.GetExtension(dosyalar).Equals(".txt"))
                    Console.WriteLine(dosyalar);
            }

            bool tryagain = true;
            while (tryagain == true)
            {
                try
                {

                    Console.WriteLine("Imaji uzantisi ile birlikte giriniz:");
                    imageAdi = Console.ReadLine();

                    tryagain = false;
                }
                catch
                {
                    Console.WriteLine("Lutfen dosya ismini dogru giriniz.");
                }
            }

            Bitmap image1 = new Bitmap(dosyaYolu + imageAdi);

            int width = image1.Width;
            int height = image1.Height;
            int a, r, g, b;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color p = image1.GetPixel(x, y);


                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    image1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            image1.Save(dosyaYolu + "Negatif " + imageAdi);
            string yeniText = imageAdi.Substring(0, imageAdi.Length - 4);
            if(!File.Exists(dosyaYolu + "Negatif " + yeniText + ".txt"))
            File.Copy(dosyaYolu + yeniText + ".txt", dosyaYolu + "Negatif " + yeniText + ".txt");
        }
       
    }
}
        
        
