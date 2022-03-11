using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace YasinRamazanLuleci
{
    class Album         //Album islemlerinin yapildigi sinif
    {
        
        protected string directory = "C:\\AlbumKlasoru\\";
        protected string albumAdi;
        protected string konum;
        protected string[] albumEtiket= new string[10];
        protected string albumTarihi;
            
        public void albumEkle()
        {
            int a;            
            Console.Write("Album adi giriniz: ");
            albumAdi = Console.ReadLine();
            Directory.CreateDirectory(directory + albumAdi);

            if (!File.Exists(directory + albumAdi + "\\veri.txt"))
            {
                var file = File.Create(directory + albumAdi + "\\veri.txt");
                file.Close();
            }
            StreamWriter _file = new StreamWriter(directory + albumAdi + "\\veri.txt");

            Console.WriteLine("Album tarihi giriniz:");
            albumTarihi = Console.ReadLine();
            _file.WriteLine(albumTarihi);

            Console.WriteLine("Albume konum bilgisi eklemek ister misiniz ?");
            Console.WriteLine("Evet icin 1 basiniz.");
            Console.WriteLine("Hayir icin herhangi bir sayi giriniz.");
            
            
            bool tryagain=true;
            while(tryagain)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a==1)
                    {
                        Console.Write("Konum giriniz: ");
                        konum = Console.ReadLine();
                        _file.WriteLine("Konum: ");
                        _file.WriteLine(konum);
                    }
                    
                    tryagain = false;
                }
                catch
                {
                    Console.WriteLine("Lutfen gecerli bir secim yapiniz.");
                }
            }

            tryagain = true;
            while (tryagain)
            {
                try
                {
                    int i=0;
                   
                    Console.Write("Kac tane etiket eklemek istersiniz ? ");
                    i = Convert.ToInt32(Console.ReadLine());
                    _file.WriteLine("Etiketler:");
                    
                    for(int j=0;j<i;j++)
                    {
                        Console.WriteLine("{0}. etiket: ",j+1);
                        albumEtiket[j] = Console.ReadLine();

                        _file.WriteLine(albumEtiket[j]);
                        
                        
                    }
                    File.SetAttributes(directory + albumAdi + "\\veri.txt", FileAttributes.Hidden);
                    tryagain = false;
                    _file.Close();
                    
                }
                catch
                {
                    Console.WriteLine("Lutfen gecerli bir secim yapiniz.");
                }
            }
            
        }

        public string albumGoster()
        {
            string[] files = Directory.GetDirectories(directory);

            if (files.Length == 0)
            {
                Console.WriteLine("Album klasoru bulunmamaktadir.");
                return "0";
            }
            else
            {
                Console.WriteLine("Mevcut albumler");
                foreach (string dosyalar in files)
                    Console.WriteLine(dosyalar);

                Console.WriteLine(); 
                return "1";
            }
        }

        public string albumArama(string albumAdi)
        {
            this.albumAdi = albumAdi;
            try
            {
                string[] dirs = Directory.GetDirectories(directory, albumAdi);
                
                return dirs[0]+"\\";
            }

            catch (Exception e)
            {
                Console.WriteLine("Islem gerceklestirilemedi: {0}", e.ToString());
                return "0";
            }
            
        }

        public void albumBilgileriArama()
        {
            bool a = true;

            Console.WriteLine("1. Album tarihi");
            Console.WriteLine("2. Konum");
            Console.WriteLine("3. Etiketler");
            Console.WriteLine("Hangi bilgiler ile arama yapacaksiniz");
            string secim = Console.ReadLine();

            string[] albumKlasorleri = Directory.GetDirectories(directory);
            

            if (secim =="1")
            {
                Console.WriteLine("Tarih giriniz:");
                string albumTarihi = Console.ReadLine();

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] file = File.ReadAllLines(klasorler + "\\veri.txt");
                    Console.WriteLine("Eslesen albumler:");

                    if (file[0] == albumTarihi)
                    {
                        Console.WriteLine(klasorler);
                        a = false;
                    }

                }
                if (a == true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else if (secim == "2")
            {
                Console.WriteLine("Konum giriniz:");
                string konum = Console.ReadLine();

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] file = File.ReadAllLines(klasorler + "\\veri.txt");
                    Console.WriteLine("Eslesen albumler:");

                    if (file[2] == konum)
                    {
                        Console.WriteLine(klasorler);
                        a = false;
                    }

                }
                if (a == true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else if (secim == "3")
            {
                Console.WriteLine("Etiket giriniz:");
                string etiket = Console.ReadLine();

                foreach (string klasorler in albumKlasorleri)
                {
                    string[] file = File.ReadAllLines(klasorler + "\\veri.txt");
                    Console.WriteLine("Eslesen albumler:");

                    for (int i = 4; i < file.Length; i++)
                    {
                        if (file[i] == etiket)
                        {
                            Console.WriteLine(klasorler);
                            a=false;
                        }
                    }
                }
                if (a == true)
                    Console.WriteLine("Eslesen imaj bulunamadi.");
            }
            else
            { Console.WriteLine("Lutfen gecerli bir secim yapiniz."); albumBilgileriArama(); }


        }
    }
}
