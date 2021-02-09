using System;
namespace Entities.Concrete
{
    public class Dilekce :Abstract.IEntity
    {
        public int Id { get; set; }
        public string DilekceNumarasi { get; set; }
        public string UretimYili { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string DilekceTarihi { get; set; }
        public string DilekceKabulTarihi { get; set; }
        public string Durum { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
    }
}
