namespace Entities.Abstract
{
    public interface IInvoice:ICompany
    {
         string FaturaNo { get; set; }

         string FaturaTarihi { get; set; }
         string UrunAdi { get; set; }

         decimal Miktar { get; set; }
        
         decimal BirimFiyat { get; set; }

         decimal ToplamMaliyet { get; set; }









    }
}
