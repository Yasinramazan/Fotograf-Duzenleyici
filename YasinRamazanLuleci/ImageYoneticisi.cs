using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace YasinRamazanLuleci
{
    enum Format
    {
        JPEG,
        gif,
        PNG
    }

    class ImageYoneticisi      //Imaj islemlerinin yapildiği sinif.
    {                          //Imaj degiskenlerini Image sinifi tuttugu icin bu sinif imaj ozellikleri ile ilgili degisken barındırmıyor

        public void olustur(string albumAdi, string path, Format format)
        {

            Image image = null;

            if (format == Format.JPEG)
            {
                image = new JPEG(path, albumAdi);
            }
            else if (format == Format.gif)       //Nesnelerin orneklenip kontrol edildigi olustur metodu
            {                                    
                image = new GIF(path, albumAdi);
            }
            else if (format == Format.PNG)
            {
                image = new PNG(path, albumAdi);
            }

        }
           
        public void etiketDegistirme(string dosyaYolu)
        {
            string dosya;
            bool a = false;
            bool b = false;
            HashSet<string> etiketler = new HashSet<string>();

            string[] Images = System.IO.Directory.GetFiles(dosyaYolu);
            foreach (string dosyalar in Images)
                if (!Path.GetExtension(dosyalar).Equals(".txt"))
                Console.WriteLine(dosyalar);

            Console.WriteLine("Etiketini degistirmek istediginiz dosyayi seciniz.");
            dosya = Console.ReadLine();

            Console.WriteLine("Hangi etiketi degistirmek istiyorsunuz ? ");


            StringBuilder newFile = new StringBuilder();
            string temp = "";
            string[] file = File.ReadAllLines(dosyaYolu + dosya + ".txt");

            foreach (string line in file)
            {
                if (a == true)
                    if (line.Contains("Konum:"))
                        break;

                if (line == dosya)
                    a = true;

                if (line == "Etiketler:")
                    b = true;

                if (b == true)
                    Console.WriteLine(line);
            }
            a = false;
            b = false;
            string degistirilecekEtiket = Console.ReadLine();
            Console.WriteLine("Yeni etiket giriniz:");
            string yeniEtiket = Console.ReadLine();

            foreach (string line in file)
            {
                if (line == degistirilecekEtiket)
                {
                    temp = line.Replace(degistirilecekEtiket, yeniEtiket);
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");
            }
            File.WriteAllText(dosyaYolu + dosya + ".txt", newFile.ToString());

        }

        public void imageSilme(string dosyaYolu)
        {
            string[] Images = System.IO.Directory.GetFiles(dosyaYolu);
            foreach (string dosyalar in Images)
            {
                if (!Path.GetExtension(dosyalar).Equals(".txt"))
                    Console.WriteLine(dosyalar);
            }

            Console.WriteLine("Silmek istediginiz dosyayi uzantisi ile birlikte yaziniz.");

            bool a = true;


            while (a)
            {
                try
                {
                    string dosya = Console.ReadLine();
                    foreach (string dosyalar in Images)
                    {
                        if (dosyalar == dosyaYolu + dosya)
                        {
                            File.Delete(dosyalar);
                            File.Delete(dosyaYolu + dosya + ".txt");
                            a = false;
                        }

                    }
                    if (a == false)
                        break;
                    else
                        Console.WriteLine("dosya adini dogru girdiginizden emin olunuz.");
                }
                catch
                {
                    Console.WriteLine("dosya adini dogru girdiginizden emin olunuz.");
                }
            }
        }

        public void konumDegistir(string dosyaYolu)
        {
            string dosya;
            bool a = false;
            string degistirilecekKonum = null;
            

            string[] Images = System.IO.Directory.GetFiles(dosyaYolu);
            foreach (string dosyalar in Images)
                Console.WriteLine(dosyalar);

            Console.WriteLine("Konumunu degistirmek istediginiz dosyayi seciniz.");
            dosya = Console.ReadLine();

            
            StringBuilder newFile = new StringBuilder();
            string temp = "";
            string[] file = File.ReadAllLines(dosyaYolu + dosya + ".txt");

            foreach (string line in file)
            {
                if (a == true)
                {
                    Console.Write("Mevcut Konum:");
                    Console.WriteLine(line);
                    degistirilecekKonum = line;

                }
                if (line == "Konum: ")
                    a = true;                
            }
            
            
            
            Console.WriteLine("Yeni konum giriniz:");
            string yeniKonum = Console.ReadLine();

            foreach (string line in file)
            {
                if (line == degistirilecekKonum)
                {
                    temp = line.Replace(degistirilecekKonum, yeniKonum);
                    newFile.Append(temp + "\r\n");
                    continue;
                }
                newFile.Append(line + "\r\n");
            }
            File.WriteAllText(dosyaYolu + dosya + ".txt", newFile.ToString());
        }

        public void imageAc(string path)
        {
            string acilacakImage;
            bool a = true;

            string[] Images = System.IO.Directory.GetFiles(path);
            foreach (string dosyalar in Images)
                if (!Path.GetExtension(dosyalar).Equals(".txt"))
                    Console.WriteLine(dosyalar);
            
            Console.WriteLine("Acmak istediginiz image uzantisi ile birlikte yaziniz:");

            while (a == true)
            {
                try
                {
                    acilacakImage = Console.ReadLine();

                    new Process
                    {
                        StartInfo = new ProcessStartInfo(path + acilacakImage)
                        {
                            UseShellExecute = true
                        }
                    }.Start();
                    a = false;
                }
                catch
                {
                    Console.WriteLine("Image adini duzgun girdiginizden emin olunuz.");
                }
            }
        }

        public static void imageBilgileriArama()
        {
            string yol = "C:\\AlbumKlasoru\\";
            bool a = true;
            bool b = true;
            
            Console.WriteLine("1. Image tarihi");
            Console.WriteLine("2. Konum");
            Console.WriteLine("3. Etiket");
            Console.WriteLine("Hangi bilgiler ile arama yapacaksiniz");
            string secim = Console.ReadLine();

            string[] albumKlasorleri = Directory.GetDirectories(yol);


            if (secim == "1")
            {
                
                Console.WriteLine("Tarih giriniz:");
                string imageTarihi = Console.ReadLine();
                Console.WriteLine("Eslesen imajlar:");

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] dosyalar = Directory.GetFiles(klasorler);
                    foreach (string bilgiler in dosyalar)
                    {
                        if (Path.GetExtension(bilgiler).Equals(".txt") && bilgiler != klasorler +"\\veri.txt" )
                        {
                            string[] satirlar = File.ReadAllLines(bilgiler);
                            

                            if (satirlar[1] == imageTarihi)
                            {
                                Console.WriteLine(bilgiler);
                                a = false;
                            }
                        }
                    }
                    
                }
                if (a ==true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else if (secim == "2")
            {
                Console.WriteLine("Konum giriniz:");
                string konum = Console.ReadLine();
                Console.WriteLine("Eslesen imajlar:");

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] dosyalar = Directory.GetFiles(klasorler);
                    foreach (string bilgiler in dosyalar)
                    {
                        if (Path.GetExtension(bilgiler).Equals(".txt") && bilgiler != klasorler + "\\veri.txt")
                        {
                            string[] satirlar = File.ReadAllLines(bilgiler);

                            foreach (string satir in satirlar)
                            {
                                if(b==false && satir == konum)
                                    Console.WriteLine(bilgiler); a = false;
                                   
                                
                                if (satir == "Konum: ")
                                    b = false;

                            }
                        }
                    }

                }
                if (a == true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else if (secim == "3")
            {
                Console.WriteLine("Etiket giriniz:");
                string etiket = Console.ReadLine();
                Console.WriteLine("Eslesen imajlar:");

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] dosyalar = Directory.GetFiles(klasorler);
                    foreach (string bilgiler in dosyalar)
                    {
                        if (Path.GetExtension(bilgiler).Equals(".txt") && bilgiler != klasorler + "\\veri.txt")
                        {
                            string[] satirlar = File.ReadAllLines(bilgiler);

                            foreach (string satir in satirlar)
                            {
                                if (satir == "Etiketler:")
                                    a = false;
                                if(a==false && satir ==etiket)
                                    Console.WriteLine(bilgiler);

                                if (satir == "Konum: ")
                                    break;

                            }
                        }
                    }

                }
                if (a == true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else
            { Console.WriteLine("Lutfen gecerli bir secim yapiniz."); imageBilgileriArama(); }
        }

        public void bilgiGetir(string yol)
        {
            string dosya;
            
            string[] Images = System.IO.Directory.GetFiles(yol);
            foreach (string dosyalar in Images)
                Console.WriteLine(dosyalar);

            Console.WriteLine("Bilgisini goruntulemek istediginiz dosyayi seciniz.");
            dosya = Console.ReadLine();


            StringBuilder newFile = new StringBuilder();
            
            string[] file = File.ReadAllLines(yol + dosya + ".txt");

            foreach (string line in file)
            {
                Console.WriteLine(line);
            }
        }
    }
}



