using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete
{
    public class YemBitkileri
    {
        public int Id { get; set; }
        public int CksId { get; set; }
        public int UrunId { get; set; }
        public int YemDosyaNo { get; set; }
        public string MuracaatTarihi { get; set; }
        public string EkilisYili { get; set; }
        public string AraziMahalle { get; set; }
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public string MuracaatAlani { get; set; }
        public string TespitEdilenAlan { get; set; }
        public string KontrolTarihi { get; set; }
        public string KontrolEdenler { get; set; }
        public string Not { get; set; }
    }
}
