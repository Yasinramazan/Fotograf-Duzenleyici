using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YasinRamazanLuleci
{
    class AlbumKlasoru      //Album klasorunun olusturuldugu sinif
    {
        private static AlbumKlasoru albumKlasoru;

        private AlbumKlasoru()
        {
            string directory = "C:\\AlbumKlasoru";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
        }
        public static AlbumKlasoru singleton()
        {
            if(albumKlasoru == null)
            {
                albumKlasoru = new AlbumKlasoru();
            }
            
            return albumKlasoru;
        }
    }
}
