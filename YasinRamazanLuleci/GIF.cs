using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YasinRamazanLuleci
{
    
    class GIF : Image       //Gif olarak kaydetme
        {
            public GIF(string path, string _albumAdi)
            {
                int i = 0;
                bool a = false;

                Console.Write("Image adini giriniz: ");
                imageAdi = Console.ReadLine();
                Console.Write("Image tarihi giriniz: ");
                tarih = Console.ReadLine();

                imageFormati = "gif";

                bool tryAgain = true;
                while (tryAgain)
                {
                    try
                    {
                        Console.Write("Kac tane etiket eklemek istersiniz ? ");

                        i = Convert.ToInt32(Console.ReadLine());
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("{0}. etiket: ", j + 1);
                            imageEtiket = Console.ReadLine();
                            etiketler.Add(imageEtiket);
                        }
                        tryAgain = false;
                    }
                    catch
                    {
                        Console.WriteLine("Islem gerceklestirilemedi. Lutfen sayi giriniz.");
                    }
                }

                StringBuilder newFile = new StringBuilder();

                string[] file = File.ReadAllLines(directory + _albumAdi + "\\veri.txt");

                foreach (string line in file)
                {
                    if (a == true)
                    {
                        imageKonum = line;
                        break;
                    }
                    if (line == "Konum: ")
                        a = true;
                }
                a = false;
                foreach (string line in file)
                {
                    if (a == true)
                    {
                        etiketler.Add(line);
                    }
                    if (line == "Etiketler:")
                        a = true;
                }



                StreamWriter _file = new StreamWriter(directory + _albumAdi + "\\" + imageAdi + ".txt");
                _file.WriteLine(imageAdi);
                _file.WriteLine("Tarih:");
                _file.WriteLine(tarih);
                _file.WriteLine("Etiketler:");
                foreach (string yazilacakEtiket in etiketler)
                    _file.WriteLine(yazilacakEtiket);
                _file.WriteLine("Konum: ");
                _file.WriteLine(imageKonum);
                File.SetAttributes(directory + _albumAdi + "\\" + imageAdi + ".txt", FileAttributes.Hidden);
            _file.Close();


                File.Create(path + imageAdi + ".gif");

            }
        }
}
    

