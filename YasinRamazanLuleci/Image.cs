using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinRamazanLuleci
{
    abstract class Image:Album          //Farklı format secenekleri ile kaydetmeyi saglayan siniflarin turedigi sinif
    {           
        protected string imageAdi;
        protected string tarih;
        protected string imageFormati;
        protected HashSet<string> etiketler = new HashSet<string>();
        protected string imageEtiket;
        protected string imageKonum;
    }

}
    
    
