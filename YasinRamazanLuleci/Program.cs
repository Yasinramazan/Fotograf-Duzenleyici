using System;
using System.IO;






namespace YasinRamazanLuleci
{
    class Program
    {
        static void Main(string[] args)
        {

            string albumAdi = null;
            string path = null;

            AlbumKlasoru.singleton(); // Tek bir album klasoru olması gerektigi icin singleton tasarimi ile olusturdum

            while (true)
            {
            Console.WriteLine();
            Console.WriteLine("Yapmak istediginiz islemi seciniz.");
            Console.WriteLine("1. Album Ekleme");
            Console.WriteLine("2. Imaj ekleme");
            Console.WriteLine("3. Imaj etiketi degistirme");
            Console.WriteLine("4. Imaj Silme");
            Console.WriteLine("5. Imaj konum bilgisi degistirme");
            Console.WriteLine("6. Imaji negatif renkliye cevirme");
            Console.WriteLine("7. Imaji GRB tonlarina donusturme");
            Console.WriteLine("8. Imaji siyah-beyaza cevirme");
            Console.WriteLine("9. Imaj acma");
            Console.WriteLine("10. Album arama");
            Console.WriteLine("11. Imaj arama");
            Console.WriteLine("12. Imaj bilgileri getir");
            Console.WriteLine("13. Cikis");

            string secim;
            secim = Console.ReadLine();
            
                if (secim == "1")
                {
                    Album album1 = new Album();
                    album1.albumEkle();

                }
                else if (secim == "2")
                {


                    Album album2 = new Album();
                    string a = album2.albumGoster(); // bu metot cogu if else icersinde var. Kontrol saglıyor ve dosyalari gosteriyor

                    if (a == "1")

                    {
                        bool tryAgain = true;
                        int i = 0;
                        do
                        {
                            Console.WriteLine("Imaj eklemek istediginiz albumu yaziniz.");
                            albumAdi = Console.ReadLine();
                            path = album2.albumArama(albumAdi);
                            if (path == "0")
                                Console.WriteLine("Album ismini dogru girdiginizde emin olunuz.");
                        } while (path == "0");


                        tryAgain = true;
                        while (tryAgain || i < 1 || i > 3)
                            try
                            {
                                ImageYoneticisi yeniImage = new ImageYoneticisi();
                                Console.WriteLine("1. JPEG");
                                Console.WriteLine("2. PNG");
                                Console.WriteLine("3. GIF");
                                Console.Write("Format seciniz: ");
                                i = Convert.ToInt32(Console.ReadLine());

                                if (i == 1)
                                    yeniImage.olustur(albumAdi, path, Format.JPEG);
                                else if (i == 2)
                                    yeniImage.olustur(albumAdi, path, Format.PNG);
                                else if (i == 3)
                                    yeniImage.olustur(albumAdi, path, Format.gif);

                                tryAgain = false;
                            }
                            catch
                            {
                                Console.WriteLine("Islem gerceklestirilemedi. Lutfen sayi giriniz.");
                            }

                    }
                }

                else if (secim == "3")
                {
                    Album album3 = new Album();
                    string a = album3.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album3.albumArama(albumAdi);

                        } while (path == "0");
                        ImageYoneticisi aranacakImage = new ImageYoneticisi();
                        aranacakImage.etiketDegistirme(path);

                    }
                }

                else if (secim == "4")
                {
                    Album album4 = new Album();
                    string a = album4.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album4.albumArama(albumAdi);

                        } while (path == "0");

                        ImageYoneticisi aranacakImage = new ImageYoneticisi();
                        aranacakImage.imageSilme(path);
                    }


                }
                else if (secim == "5")
                {
                    Album album5 = new Album();
                    string a = album5.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album5.albumArama(albumAdi);

                        } while (path == "0");

                        ImageYoneticisi konumImage = new ImageYoneticisi();
                        konumImage.konumDegistir(path);
                    }

                }
                else if (secim == "6")
                {
                    Album album6 = new Album();
                    string a = album6.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album6.albumArama(albumAdi);

                        } while (path == "0");

                        Secenekler sec = new Secenekler();
                        sec.secenek(new Negatif());
                        sec.kaydet(path);

                    }

                }
                else if (secim == "7")
                {
                    Album album7 = new Album();
                    string a = album7.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album7.albumArama(albumAdi);

                        } while (path == "0");

                        Secenekler sec = new Secenekler();
                        sec.secenek(new RGBtoGRB());
                        sec.kaydet(path);

                    }


                }
                else if (secim == "8")
                {
                    Album album8 = new Album();
                    string a = album8.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album8.albumArama(albumAdi);

                        } while (path == "0");

                        Secenekler sec = new Secenekler();
                        sec.secenek(new SiyahBeyaz());
                        sec.kaydet(path);


                    }
                }
                else if (secim == "9")
                {
                    Album album9 = new Album();
                    string a = album9.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album9.albumArama(albumAdi);

                        } while (path == "0");
                        ImageYoneticisi ac = new ImageYoneticisi();
                        ac.imageAc(path);
                    }


                }
                else if (secim == "10")
                {
                    Album album10 = new Album();
                    string a = album10.albumGoster();
                    if (a == "1")
                    {

                        album10.albumBilgileriArama();
                    }
                }
                else if (secim == "11")
                {
                    Album album11 = new Album();
                    string a = album11.albumGoster();
                    if (a == "1")
                    {
                        ImageYoneticisi.imageBilgileriArama();
                    }

                }
                else if (secim == "12")
                {
                    Album album12 = new Album();
                    string a = album12.albumGoster();
                    if (a == "1")
                    {
                        do
                        {
                            Console.WriteLine("Imaj dosyasi hangi albumde ?");
                            albumAdi = Console.ReadLine();

                            path = album12.albumArama(albumAdi);

                        } while (path == "0");
                        ImageYoneticisi getir = new ImageYoneticisi();
                        getir.bilgiGetir(path);
                    }
                }
                else if (secim == "13")
                {
                    Environment.Exit(0);
                }
            }
        }
    }

   
}
