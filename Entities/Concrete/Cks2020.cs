using Entities.Abstract;

namespace Entities.Concrete
{
    public class Cks2020 : ICks
    {
        public int Id { set; get; }

        public int DosyaNo { set; get; }
        public string Tc { set; get; }
        public string IsimSoyisim { set; get; }
        public string BabaAdi { set; get; }
        public string KoyMahalle { set; get; }
        public string CepTelefonu { set; get; }
        public string EvTelefonu { set; get; }
        public string KayitTarihi { set; get; }
    }
}
