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
        public string Tutar { get; set; }
        public string Group { get; set; }
        public string Not { get; set; }

        public string TutarHesapla()
        {
            var miktar=Convert.ToInt32(this.Miktar);
            var fiyat = Convert.ToInt32(this.Fiyat);
            return (miktar * fiyat).ToString();

        }

    }
}
