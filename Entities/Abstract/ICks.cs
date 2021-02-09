using System;
namespace Entities.Abstract
{
    public interface ICks:IEntity
    {
        int DosyaNo { set; get; }
        string Tc { set; get; }
        string IsimSoyisim { set; get; }
        string BabaAdi { set; get; }
        string KoyMahalle { set; get; }
        string CepTelefonu { set; get; }
        string EvTelefonu { set; get; }
        string KayitTarihi { set; get; }
    }
}
