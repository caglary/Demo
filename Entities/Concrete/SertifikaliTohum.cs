using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SertifikaliTohum
    {
        public int Id { get; set; }
        public int CksId { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public int SertifikaliDosyaNo { get; set; }
        public string MuracaatTarihi { get; set; }
        public string SertifikaNo { get; set; }
        public string FaturaNo { get; set; }
        public string FaturaTarihi { get; set; }
       
        public string Miktari { get; set; }
        public string BirimFiyati { get; set; }
        public string ToplamMaliyet { get { return Toplam(); } }
        public string Not { get; set; }
        private string Toplam()
        {
            return (Convert.ToInt32(Miktari) * Convert.ToInt32(BirimFiyati)).ToString();
        }


    }
}
