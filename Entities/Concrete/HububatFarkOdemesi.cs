using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HububatFarkOdemesi
    {
        public int Id { get; set; }
        public int CksId { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }


        public int HububatDosyaNo { get; set; }
        public string MuracaatTarihi { get; set; }
        
        public string FaturaTarihi { get; set; }
        public string FaturaNo { get; set; }
       
        public string Miktar { get; set; }
        public string Fiyat { get; set; }
        public string Tutar { get { return TutarHesapla(); } }
        
        public string Not { get; set; }

        public string TutarHesapla()
        {
            if (Miktar.Contains(",")) Miktar = Miktar.Replace(",", ".");
            if (Fiyat.Contains(",")) Fiyat = Fiyat.Replace(",", ".");

            var sonuc = (Convert.ToDecimal(Miktar) * Convert.ToDecimal(Fiyat)).ToString();
            return sonuc;
        }

    }
}
