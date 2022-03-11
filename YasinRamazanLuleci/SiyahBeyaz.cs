using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace YasinRamazanLuleci
{
    class SiyahBeyaz : IImageDuzenleyici        //Imaji siyah beyaza ceviren sinif
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

            Bitmap image3 = new Bitmap(dosyaYolu + imageAdi);

            int width = image3.Width;
            int height = image3.Height;
            Color p;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    p = image3.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    image3.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));

                }
            }
            image3.Save(dosyaYolu + "Siyah-Beyaz " + imageAdi);
            string yeniText = imageAdi.Substring(0, imageAdi.Length - 4);
            if (!File.Exists(dosyaYolu + "Siyah-Beyaz " + yeniText + ".txt"))
                File.Copy(dosyaYolu + yeniText + ".txt", dosyaYolu + "Siyah-Beyaz " + yeniText + ".txt");
        }

    }
}
