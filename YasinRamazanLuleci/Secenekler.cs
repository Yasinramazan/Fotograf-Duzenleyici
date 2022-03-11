using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinRamazanLuleci
{
    class Secenekler        //Nesnelerin fonksiyonlar üzerinden degiskenlerle kontrol edildigi secenekler sinifi
    {
        private IImageDuzenleyici _imageDuzenle;
        
        public void secenek(IImageDuzenleyici imageDuzenle)
        {
            _imageDuzenle = imageDuzenle;
        }
        public void kaydet(string path)
        {                                       
            this._imageDuzenle.kaydet(path);
        }
        
    }
}
