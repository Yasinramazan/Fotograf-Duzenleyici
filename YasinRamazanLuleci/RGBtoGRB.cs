using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace YasinRamazanLuleci
{
    class RGBtoGRB : IImageDuzenleyici      //Imaji yesil tonlarina ceviren sinif
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

            Bitmap image2 = new Bitmap(dosyaYolu + imageAdi);

            int width = image2.Width;
            int height = image2.Height;
            

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color p = image2.GetPixel(x, y);


                    Color gotColor = image2.GetPixel(x, y);
                    gotColor = Color.FromArgb(gotColor.G, gotColor.R, gotColor.B);
                    image2.SetPixel(x, y, gotColor);

                }
            }
            image2.Save(dosyaYolu + "GRB " + imageAdi);
            string yeniText = imageAdi.Substring(0, imageAdi.Length - 4);
            if (!File.Exists(dosyaYolu + "GRB " + yeniText + ".txt"))
                File.Copy(dosyaYolu + yeniText + ".txt", dosyaYolu + "GRB " + yeniText + ".txt");
        }
    }
}
